using MediatR;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<CreateUserHandler> logger;

        public CreateUserHandler(IUserRepository userRepository, ILogger<CreateUserHandler> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var role = RoleConstants.User;
                switch (request.Role)
                {
                    case RoleConstants.Admin:
                        role = RoleConstants.IDAdmin;
                        break;
                    case RoleConstants.Supporter:
                        role = RoleConstants.IDSupporter;
                        break;
                    case RoleConstants.Doctor:
                        role = RoleConstants.IDDoctor;
                        break;
                    case RoleConstants.Expert:
                        role = RoleConstants.IDExpert;
                        break;
                    case RoleConstants.User:
                        role = RoleConstants.IDUser;
                        break;
                }
                var userNameGeneration = role.ToLower() + request.Email.Substring(0, request.Email.IndexOf('@'));
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                var user = new User { UserName = userNameGeneration, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = role };
                var result = await userRepository.CreateEntityAsync(user);
                if (result == null)
                {
                    throw new Exception("Create User Erorr.");
                }
                var account = new ProviderAccountDtos { UserName = userNameGeneration, Password = passwordGeneration };
                return user.UserID;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return Guid.Empty;
            }
        }
    }
}

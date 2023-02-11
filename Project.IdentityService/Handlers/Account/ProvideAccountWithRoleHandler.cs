using MediatR;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Protos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ProvideAccountWithRoleHandler : IRequestHandler<ProvideAccountWithRoleCommand, AccountResponse>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<ProvideAccountWithRoleHandler> logger;

        public ProvideAccountWithRoleHandler(IUserRepository userRepository, ILogger<ProvideAccountWithRoleHandler> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<AccountResponse> Handle(ProvideAccountWithRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userNameGeneration = RoleConstants.Doctor.ToLower() + request.Email.Substring(0, request.Email.IndexOf('@'));
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                var user = new User { UserName = userNameGeneration, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = request.Role };
                var result = await userRepository.CreateEntityAsync(user);
                if (result == null)
                {
                    return new AccountResponse { IsSuccess = false };
                }
                return new AccountResponse { IsSuccess = true, UserID = result.UserID.ToString() };
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return new AccountResponse { IsSuccess = false };
            }
        }
    }
}

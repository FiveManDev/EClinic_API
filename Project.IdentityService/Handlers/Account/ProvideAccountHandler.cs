using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Dtos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ProvideAccountHandler : IRequestHandler<ProvideAccountCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<ProvideAccountHandler> logger;

        public ProvideAccountHandler(IUserRepository userRepository, ILogger<ProvideAccountHandler> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(ProvideAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetAsync(request.UserID);
                if (user == null)
                {
                    return ApiResponse.NotFound("User Not Found.");
                }
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                user.PasswordSalt = pass.Salt;
                user.PasswordHash = pass.Hash;
                var result = await userRepository.UpdateAsync(user);
                if (!result)
                {
                    return ApiResponse.InternalServerError();
                }
                var signInDtos = new SignInDtos { UserName = user.UserName, Password = passwordGeneration };
                return ApiResponse.Created<SignInDtos>(signInDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

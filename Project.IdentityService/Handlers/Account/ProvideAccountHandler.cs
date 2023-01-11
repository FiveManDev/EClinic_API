using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Constants;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Common.Security;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Dtos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ProvideAccountHandler : IRequestHandler<ProvideAccountCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;

        public ProvideAccountHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ObjectResult> Handle(ProvideAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isMailExist = await userRepository.AnyAsync(user => user.Email == request.ProvideAccount.Email);
                if (isMailExist)
                {
                    return ApiResponse.BadRequest("EMail is exist");
                }
                var userNameGeneration = RoleConstants.Doctor.ToLower() + request.ProvideAccount.Email.Substring(0, request.ProvideAccount.Email.IndexOf('@')) + RandomText.RandomByNumberOfCharacters(6, RandomType.String);
                var passwordGeneration = RandomText.RandomByNumberOfCharacters(15, RandomType.String);
                var pass = Cryptography.EncryptPassword(passwordGeneration);
                var user = new User { UserName = userNameGeneration, Email = request.ProvideAccount.Email, PasswordHash = pass.Hash, PasswordSalt = pass.Salt, RoleID = request.Role };
                var result = await userRepository.CreateAsync(user);
                if (!result)
                {
                    return ApiResponse.InternalServerError();
                }
                var signInDtos = new SignInDtos { UserName = userNameGeneration, Password = passwordGeneration };
                return ApiResponse.Created<SignInDtos>(signInDtos);
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Authentication;
using Project.Core.Model;
using Project.IdentityService.Commands;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Authentication
{
    public class SignInHandler : IRequestHandler<SignInCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public SignInHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task<ObjectResult> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetAsync(user => user.UserName == request.SignInDtos.UserName);
                if (user == null)
                {
                    return ApiResponse.NotFound("Email or password is incorrect");
                }
                if (Cryptography.VerifyPassword(request.SignInDtos.Password, user.PasswordSalt, user.PasswordHash))
                {
                    var role = await roleRepository.GetAsync(role => role.RoleID == user.RoleID);
                    var tokenInformation = new JWTTokenInformation { Role = role.RoleName, UserID = user.UserID };
                    var tokenModel = TokenExtensions.GetToken(tokenInformation);
                    return ApiResponse.OK(tokenModel);
                }
                return ApiResponse.NotFound("Email or password is incorrect");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

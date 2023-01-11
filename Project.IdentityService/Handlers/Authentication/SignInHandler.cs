using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Common.Security;
using Project.Core.Authentication;
using Project.Core.Model;
using Project.IdentityService.Commands;
using Project.IdentityService.Data;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.TokenRepository;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Authentication
{
    public class SignInHandler : IRequestHandler<SignInCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly ITokenRepository tokenRepository;

        public SignInHandler(IUserRepository userRepository, IRoleRepository roleRepository, ITokenRepository tokenRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.tokenRepository = tokenRepository;
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
                    var token = await tokenRepository.GetAsync(token => token.UserID == user.UserID);
                    bool tokenResult = false;
                    if (token == null)
                    {
                        tokenResult = await tokenRepository.CreateAsync(new Token { AccessToken = tokenModel.AccessToken, RefreshToken = tokenModel.RefreshToken, UserID = user.UserID });
                    }
                    else
                    {
                        token.AccessToken = tokenModel.AccessToken;
                        token.RefreshToken = tokenModel.RefreshToken;
                        token.UpdateAt = DateTime.Now;
                        tokenResult = await tokenRepository.UpdateAsync(token);
                    }
                    if (!tokenResult)
                    {
                        return ApiResponse.InternalServerError();
                    }
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

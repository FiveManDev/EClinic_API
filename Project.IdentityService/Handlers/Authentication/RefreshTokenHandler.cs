using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Authentication;
using Project.Core.Model;
using Project.IdentityService.Commands;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.TokenRepository;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Authentication
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly ITokenRepository tokenRepository;

        public RefreshTokenHandler(IUserRepository userRepository, IRoleRepository roleRepository, ITokenRepository tokenRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.tokenRepository = tokenRepository;
        }

        public async Task<ObjectResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var IsValidate = TokenExtensions.IsValidationToken(request.TokenModel.RefreshToken);
                if (!IsValidate)
                {
                    return ApiResponse.Unauthorized("This token is not part of the system.");
                }
                var isExpires = TokenExtensions.CheckExpires(request.TokenModel.RefreshToken);
                if (isExpires)
                {
                    return ApiResponse.Unauthorized("Token has expired.");
                }
                var userID = TokenExtensions.GetID(request.TokenModel.RefreshToken);
                var user = await userRepository.GetAsync(userID);
                if (user == null)
                {
                    return ApiResponse.NotFound("Token not exist.");
                }
                var role = await roleRepository.GetAsync(role => role.RoleID == user.RoleID);
                var tokenInformation = new JWTTokenInformation { Role = role.RoleName, UserID = user.UserID };
                var tokenModel = TokenExtensions.GetToken(tokenInformation);
                var token = await tokenRepository.GetAsync(token => token.UserID == userID);
                bool tokenResult = false;
                token.AccessToken = tokenModel.AccessToken;
                token.RefreshToken = tokenModel.RefreshToken;
                token.UpdateAt = DateTime.Now;
                tokenResult = await tokenRepository.UpdateAsync(token);
                if (!tokenResult)
                {
                    return ApiResponse.InternalServerError();
                }
                return ApiResponse.OK(tokenModel);
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

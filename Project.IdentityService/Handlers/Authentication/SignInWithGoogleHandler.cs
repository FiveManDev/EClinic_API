using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Repository.RoleRepository;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Authentication
{
    public class SignInWithGoogleHandler : IRequestHandler<SignInWithGoogleCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly ILogger<SignInHandler> logger;

        public SignInWithGoogleHandler(IUserRepository userRepository, IRoleRepository roleRepository, ILogger<SignInHandler> logger)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(SignInWithGoogleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                
                return ApiResponse.InternalServerError();
            }
            catch(Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

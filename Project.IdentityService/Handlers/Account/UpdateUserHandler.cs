using MediatR;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UpdateUserHandler> logger;

        public UpdateUserHandler(IUserRepository userRepository, ILogger<UpdateUserHandler> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetAsync(request.UserID);
                if (user == null)
                {
                    return false;
                }
                if (user.Enabled == request.Enabled)
                {
                    return true;
                }
                user.Enabled = request.Enabled;
                var result = await userRepository.UpdateAsync(user);
                if (!result)
                {
                    throw new Exception("Update User Erorr.");
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return false;
            }
        }
    }
}

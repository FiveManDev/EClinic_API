using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.IdentityService.Commands;
using Project.IdentityService.Dtos;
using Project.IdentityService.Repository.UserRepository;

namespace Project.IdentityService.Handlers.Account
{
    public class ChangeStatusHandler : IRequestHandler<ChangeStatusCommand, ObjectResult>
    {
        private readonly IUserRepository userRepository;

        public ChangeStatusHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<ObjectResult> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await userRepository.GetAsync(request.AccountStatusDtos.UserID);
                user.Enabled = request.AccountStatusDtos.Enable;
                var result = await userRepository.UpdateAsync(user);
                if (!result) { throw new Exception("Update faild"); }
                return ApiResponse.OK("Change status success");
            }
            catch
            {
                return ApiResponse.InternalServerError();
            }
        }
    }
}

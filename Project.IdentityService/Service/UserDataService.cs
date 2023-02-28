using Grpc.Core;
using MediatR;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Protos;
using Project.IdentityService.Queries;

namespace Project.IdentityService.Service
{
    public class UserDataService : Protos.UserService.UserServiceBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<UserDataService> logger;

        public UserDataService(IMediator mediator, ILogger<UserDataService> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            try
            {
                var result = await mediator.Send(new CreateUserCommand(request.Email, request.Role));
                var res = new CreateUserResponse();
                if(result == Guid.Empty)
                {
                    res.IsSuccess = false;
                    return res;
                }
                res.IsSuccess = true;
                res.UserID = res.ToString();
                return res;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                var res = new CreateUserResponse();
                return res;
            }
        }

        public override async Task<GetAllUserWithRoleResponse> GetAllUserWithRole(GetAllUserWithRoleRequest request, ServerCallContext context)
        {
            try
            {
                var UserIDs = await mediator.Send(new GetAllUserWithRoleQuery(request.Role)); 
                List<string> listID = UserIDs.Select(s => s.ToString()).ToList();
                GetAllUserWithRoleResponse getAllUser = new GetAllUserWithRoleResponse();
                getAllUser.UserIDs.AddRange(listID);
                return getAllUser;
            }
            catch
            {
                return new GetAllUserWithRoleResponse();
            }
        }
    }
}


using Grpc.Core;
using MediatR;
using Project.Core.Logger;
using Project.IdentityService.Commands;
using Project.IdentityService.Protos;

namespace Project.IdentityService.Service
{
    public class AccountDataService : Protos.AccountService.AccountServiceBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<AccountDataService> logger;

        public AccountDataService(IMediator mediator, ILogger<AccountDataService> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public override async Task<AccountResponse> CreateAccount(CreateAccountRequest request, ServerCallContext context)
        {
            var result = await mediator.Send(new ProvideAccountWithRoleCommand(request.Email, request.Role));
            logger.WriteLogError("Send information to Profile");
            return result;
        }

    }
}

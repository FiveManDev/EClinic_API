using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Caching.Service;
using Project.Core.Logger;
using Project.IdentityService.Commands;

namespace Project.IdentityService.Handlers.Account
{
    public class ResendCodeHandler : IRequestHandler<ReSendCodeCommand, ObjectResult>
    {
        private readonly IBus bus;
        private ILogger<ResendCodeHandler> logger;
        private readonly IResponseCacheService cacheService;

        public ResendCodeHandler(IBus bus, ILogger<ResendCodeHandler> logger, IResponseCacheService cacheService)
        {
            this.bus = bus;
            this.logger = logger;
            this.cacheService = cacheService;
        }

        async Task<ObjectResult> IRequestHandler<ReSendCodeCommand, ObjectResult>.Handle(ReSendCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(500);
                return ApiResponse.OK("");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

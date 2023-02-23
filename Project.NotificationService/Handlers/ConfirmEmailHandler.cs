using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.Core.Logger;
using Project.NotificationService.Commands;
using Project.NotificationService.Service;

namespace Project.NotificationService.Handlers
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, ObjectResult>
    {
        private readonly ILogger<ConfirmEmailHandler> logger;
        private readonly IMailService mailService;

        public ConfirmEmailHandler(ILogger<ConfirmEmailHandler> logger, IMailService mailService)
        {
            this.logger = logger;
            this.mailService = mailService;
        }

        public async Task<ObjectResult> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var code = RandomText.RandomByNumberOfCharacters(6, RandomType.Number);
                mailService.ConfirmEmail(request.email, code);
                await Task.Delay(0);
                return ApiResponse.OK<string>(code);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

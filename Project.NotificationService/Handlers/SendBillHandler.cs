using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Enum;
using Project.Common.Functionality;
using Project.Common.Response;
using Project.NotificationService.Commands;
using Project.NotificationService.Service;
using Project.Core.Logger;
namespace Project.NotificationService.Handlers
{
    public class SendBillHandler : IRequestHandler<SendBillCommand, ObjectResult>
    {
        private readonly ILogger<SendBillHandler> logger;
        private readonly IMailService mailService;

        public SendBillHandler(ILogger<SendBillHandler> logger, IMailService mailService)
        {
            this.logger = logger;
            this.mailService = mailService;
        }

        public async Task<ObjectResult> Handle(SendBillCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var code = RandomText.RandomByNumberOfCharacters(6, RandomType.Number);
                mailService.SendBill(request.email,request.PaymentModel);
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

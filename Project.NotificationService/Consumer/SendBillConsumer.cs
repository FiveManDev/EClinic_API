using MassTransit;
using Project.Core.Logger;
using Project.NotificationService.Dtos;
using Project.NotificationService.Service;

namespace Project.NotificationService.Consumer
{
    public class SendBillConsumer : IConsumer<PaymentModelData>
    {
        private readonly IMailService mailService;
        private ILogger<SendBillConsumer> logger;

        public SendBillConsumer(IMailService mailService, ILogger<SendBillConsumer> logger)
        {
            this.mailService = mailService;
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentModelData> context)
        {
            try
            {
                mailService.SendBill(context.Message.Email, context.Message);
                return Task.CompletedTask;
            }catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return Task.FromException(ex);
            }
        }
    }
}

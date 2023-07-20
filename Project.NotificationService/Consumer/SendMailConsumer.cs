using MassTransit;
using Project.Core.Logger;
using Project.NotificationService.Dtos;
using Project.NotificationService.Service;

namespace Project.NotificationService.Consumer
{
    public class SendMailConsumer : IConsumer<VerifyEmail>
    {
        private readonly IMailService mailService;
        private ILogger<SendMailConsumer> logger;

        public SendMailConsumer(IMailService mailService, ILogger<SendMailConsumer> logger)
        {
            this.mailService = mailService;
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<VerifyEmail> context)
        {
            try
            {
                int type = context.Message.Type;
                string email = context.Message.Email;
                string code = context.Message.Code;
                if (type == 0) {
                    mailService.ConfirmEmail(email, code);
                }
                if(type == 1)
                {
                    mailService.VerifyEmail(email, code);
                }
                return Task.CompletedTask;
            }catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return Task.FromException(ex);
            }
        }
    }
}

using MassTransit;
using Project.Core.Logger;
using Project.NotificationService.Dtos;
using Project.NotificationService.Service;

namespace Project.NotificationService.Consumer
{
    public class SendAccountConsumer : IConsumer<AccountDtos>
    {
        private readonly IMailService mailService;
        private ILogger<SendAccountConsumer> logger;

        public SendAccountConsumer(IMailService mailService, ILogger<SendAccountConsumer> logger)
        {
            this.mailService = mailService;
            this.logger = logger;
        }

        public Task Consume(ConsumeContext<AccountDtos> context)
        {
            try
            {
                mailService.SendAccount(context.Message.Email, context.Message);
                return Task.CompletedTask;
            }catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return Task.FromException(ex);
            }
        }
    }
}

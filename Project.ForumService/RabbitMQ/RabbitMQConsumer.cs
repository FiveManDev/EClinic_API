using MassTransit;
using Project.IdentityService.Data;

namespace Project.IdentityService.RabbitMQ
{
    public class RabbitMQConsumer : IConsumer<User>
    {

        public Task Consume(ConsumeContext<User> context)
        {
            var x = context.RoutingKey();
            User data = context.Message;
            Console.WriteLine(data.UserID);
            Console.WriteLine(x + "Khang");
            return Task.CompletedTask;
        }
    }
}

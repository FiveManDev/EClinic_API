using MassTransit;
using Project.ForumService.Data;
using Project.IdentityService.Data;

namespace Project.IdentityService.RabbitMQ
{
    public class RabbitMQProfileConsumer : IConsumer<User>
    {
        public Task Consume(ConsumeContext<User> context)
        {
            var x = context.RoutingKey();
            User data = context.Message;
            Console.WriteLine(data.UserID);
            Console.WriteLine(x+"KhangProfile");
            return Task.CompletedTask;
        }
    }
}

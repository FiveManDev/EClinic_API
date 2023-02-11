//using MassTransit;
//using Newtonsoft.Json;
//using Project.IdentityService.Events.ProfileEvents;

//namespace Project.IdentityService.RabbitMQ
//{
//    public class RabbitMQConsumer : IConsumer<CreateProfileEvent>
//    {

//        public Task Consume(ConsumeContext<CreateProfileEvent> context)
//        {
//            Console.WriteLine("Khang");
//            var user = context.Message;
//            var x = JsonConvert.SerializeObject(user);
//            Console.WriteLine(x);
//            return Task.CompletedTask;
//        }
//    }
//}

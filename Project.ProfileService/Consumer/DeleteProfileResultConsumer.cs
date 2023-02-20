﻿using MassTransit;
using Project.ProfileService.Events;

namespace Project.ProfileService.Consumer
{
    public class DeleteProfileResultConsumer : IConsumer<DeleteProfileResultEvents>
    {
        private readonly IBus bus;

        public DeleteProfileResultConsumer(IBus bus)
        {
            this.bus = bus;
        }

        public async Task Consume(ConsumeContext<DeleteProfileResultEvents> context)
        {
            var result = context.Message.IsSuccess;
            if (!result)
            {
                await bus.Send(new DeleteProfileEvents { UserID = context.Message.UserID });
            }
        }
    }
}

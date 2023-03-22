using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

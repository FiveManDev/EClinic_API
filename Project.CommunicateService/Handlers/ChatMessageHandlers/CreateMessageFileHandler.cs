using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.ChatMessageHandlers
{
    public class CreateMessageFileHandler : IRequestHandler<CreateMessageFileCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(CreateMessageFileCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

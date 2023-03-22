using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.VideoCallHandlers
{
    public class CreateVideoCallHandler : IRequestHandler<CreateVideoCallCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(CreateVideoCallCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

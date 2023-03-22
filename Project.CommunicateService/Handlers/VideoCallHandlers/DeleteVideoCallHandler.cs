using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.VideoCallHandlers
{
    public class DeleteVideoCallHandler : IRequestHandler<DeleteVideoCallCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(DeleteVideoCallCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

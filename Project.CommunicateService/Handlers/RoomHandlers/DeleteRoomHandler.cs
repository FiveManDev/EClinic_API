using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class DeleteRoomHandler : IRequestHandler<DeleteRoomCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

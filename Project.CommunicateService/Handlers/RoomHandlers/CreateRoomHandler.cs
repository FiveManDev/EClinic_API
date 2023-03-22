using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class CreateRoomHandler : IRequestHandler<CreateRoomCommand, ObjectResult>
    {
        public Task<ObjectResult> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

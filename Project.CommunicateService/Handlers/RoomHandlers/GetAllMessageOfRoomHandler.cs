using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Queries;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllMessageOfRoomHandler : IRequestHandler<GetAllMessageOfRoomQuery, ObjectResult>
    {
        public Task<ObjectResult> Handle(GetAllMessageOfRoomQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Queries;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllRoomOfRoomTypeHandler : IRequestHandler<GetAllRoomOfRoomTypeQuery, ObjectResult>
    {
        public Task<ObjectResult> Handle(GetAllRoomOfRoomTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class CloseRoomHandler : IRequestHandler<CloseRoomCommand, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly ILogger<CloseRoomHandler> logger;

        public CloseRoomHandler(IRoomRepository roomRepository, ILogger<CloseRoomHandler> logger)
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CloseRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = await roomRepository.GetAsync(request.RoomID);
                if(Room.IsClosed)
                {
                    return ApiResponse.BadRequest("Room is close");
                }
                Room.IsClosed = true;
                var result = await roomRepository.UpdateAsync(Room);
                if (!result)
                {
                    throw new Exception("Close Room Error.");
                }
                return ApiResponse.OK("Close room is success");
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

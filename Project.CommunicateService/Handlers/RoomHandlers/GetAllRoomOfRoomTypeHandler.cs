using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Queries;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllRoomOfRoomTypeHandler : IRequestHandler<GetAllRoomOfRoomTypeQuery, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly ILogger<GetAllMessageOfRoomHandler> logger;

        public GetAllRoomOfRoomTypeHandler(IRoomRepository roomRepository, IMapper mapper, ILogger<GetAllMessageOfRoomHandler> logger)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetAllRoomOfRoomTypeQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var Rooms = await roomRepository.GetAllRoom(x => x.RoomTypeID == request.RoomTypeID);
                if (Rooms == null)
                {
                    return ApiResponse.NotFound("Room Not Found");
                }
                return ApiResponse.InternalServerError();
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

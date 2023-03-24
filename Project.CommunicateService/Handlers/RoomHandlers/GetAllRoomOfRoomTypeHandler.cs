using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Queries;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.AWS;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class GetAllRoomOfRoomTypeHandler : IRequestHandler<GetAllRoomOfRoomTypeQuery, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly ILogger<GetAllMessageOfRoomHandler> logger;

        public GetAllRoomOfRoomTypeHandler(IRoomRepository roomRepository, IMapper mapper, IAmazonS3Bucket s3Bucket, ILogger<GetAllMessageOfRoomHandler> logger)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
            this.s3Bucket = s3Bucket;
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

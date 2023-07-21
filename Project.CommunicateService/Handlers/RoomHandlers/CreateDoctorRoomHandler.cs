using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Data.Configurations;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class CreateDoctorRoomHandler : IRequestHandler<CreateDoctorRoomCommand, ObjectResult>
    {
        private readonly IRoomRepository roomRepository;
        private readonly ILogger<CreateDoctorRoomHandler> logger;

        public CreateDoctorRoomHandler(IRoomRepository roomRepository, ILogger<CreateDoctorRoomHandler> logger)
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(CreateDoctorRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = new Room { RoomTypeID = ConstantsData.DoctorRoomTypeID };
                var result = await roomRepository.CreateEntityAsync(Room);
                if (result == null)
                {
                    throw new Exception("Create Room Error.");
                }
                return ApiResponse.Created<Guid>(result.RoomID);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

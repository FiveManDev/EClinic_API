using MediatR;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Data;
using Project.CommunicateService.Data.Configurations;
using Project.CommunicateService.Repository.ChatMessageRepositories;
using Project.CommunicateService.Repository.RoomRepositories;
using Project.Core.Logger;

namespace Project.CommunicateService.Handlers.RoomHandlers
{
    public class CreateDoctorRoomHandler : IRequestHandler<CreateDoctorRoomCommand, Room>
    {
        private readonly IRoomRepository roomRepository;
        private readonly ILogger<CreateDoctorRoomHandler> logger;
        private readonly IChatMessageRepository repository;

        public CreateDoctorRoomHandler(IRoomRepository roomRepository, ILogger<CreateDoctorRoomHandler> logger, IChatMessageRepository repository)
        {
            this.roomRepository = roomRepository;
            this.logger = logger;
            this.repository = repository;
        }

        public async Task<Room> Handle(CreateDoctorRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Room = new Room { RoomTypeID = ConstantsData.DoctorRoomTypeID };
                var result = await roomRepository.CreateEntityAsync(Room);
                await repository.CreateRangeAsync(new List<ChatMessage>
                {
                    new ChatMessage{UserID = Guid.Parse(request.UserID),Content= "Hidden",RoomID = result.RoomID,Type =MessageType.Hidden},
                    new ChatMessage{UserID = Guid.Parse(request.DoctorID),Content= "Hidden",RoomID = result.RoomID,Type =MessageType.Hidden}
                });
                if (result == null)
                {
                    throw new Exception("Create Room Error.");
                }
                return Room;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}

using Grpc.Core;
using MediatR;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Protos;
using Project.Core.Logger;

namespace Project.CommunicateService.Service
{
    public class CommunicationDataService : Protos.CommunicationService.CommunicationServiceBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<CommunicationDataService> logger;

        public CommunicationDataService(IMediator mediator, ILogger<CommunicationDataService> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        public override async Task<CreateRoomResponse> CreateRoom(CreateRoomRequest request, ServerCallContext context)
        {
            try
            {
                var result = await mediator.Send(new CreateDoctorRoomCommand());
                return new CreateRoomResponse { RoomID = result.RoomID.ToString() };
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}

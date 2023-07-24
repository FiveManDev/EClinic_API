using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using Project.BookingService.Data;
using Project.BookingService.Protos;
using Project.BookingService.Repository.BookingDoctorRepository;
using Project.BookingServiceCommands.Commands;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingDoctorHandler
{
    public class CreateBookingDoctorHandler : IRequestHandler<CreateBookingDoctorCommand, BookingDoctor>
    {
        private readonly ILogger<CreateBookingDoctorHandler> logger;
        private readonly IBookingDoctorRepository repository;
        private readonly IMapper mapper;
        private readonly CommunicationService.CommunicationServiceClient client;
        public CreateBookingDoctorHandler(IConfiguration configuration, IBookingDoctorRepository repository, ILogger<CreateBookingDoctorHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:CommunicationServiceURL"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new CommunicationService.CommunicationServiceClient(channel);
        }
        public async Task<BookingDoctor> Handle(CreateBookingDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BookingDoctor bookingDoctor = mapper.Map<BookingDoctor>(request.CreateBookingDoctorDTO);
                var res = await client.CreateRoomAsync(new CreateRoomRequest { Type = 1 });
                if (res == null) { return null; }
                if (bookingDoctor.BookingType == BookingType.Offline)
                {
                    bookingDoctor.RoomID = Guid.NewGuid();
                }
                if (bookingDoctor.BookingType == BookingType.Online)
                {
                    bookingDoctor.RoomID = Guid.Parse(res.RoomID);
                }
                bookingDoctor.BookingStatus = BookingStatus.NoPayment;
                bookingDoctor.BookingTime = DateTime.Now;

                return await repository.CreateEntityAsync(bookingDoctor);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}

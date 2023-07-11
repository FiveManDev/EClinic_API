using AutoMapper;
using MediatR;
using Project.BookingService.Data;
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

        public CreateBookingDoctorHandler(IBookingDoctorRepository repository, ILogger<CreateBookingDoctorHandler> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<BookingDoctor> Handle(CreateBookingDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BookingDoctor bookingDoctor = mapper.Map<BookingDoctor>(request.CreateBookingDoctorDTO);

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

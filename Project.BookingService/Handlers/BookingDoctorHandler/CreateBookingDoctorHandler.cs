using MediatR;
using Project.BookingService.Data;
using Project.BookingServiceCommands.Commands;

namespace Project.BookingService.Handlers.BookingDoctorHandler
{
    public class CreateBookingDoctorHandler : IRequestHandler<CreateBookingDoctorCommand, BookingDoctor>
    {
        public Task<BookingDoctor> Handle(CreateBookingDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

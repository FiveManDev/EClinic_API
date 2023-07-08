using MediatR;
using Project.BookingService.Data;
using Project.BookingService.Repository.BookingDoctorRepository;
using Project.BookingServiceCommands.Commands;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingDoctorHandler;

public class UpdateBookingUpcomingForBookingDoctorHandler : IRequestHandler<UpdateBookingUpcomingForBookingDoctorCommand, BookingDoctor>
{
    private readonly ILogger<UpdateBookingUpcomingForBookingDoctorHandler> logger;
    private readonly IBookingDoctorRepository repository;

    public UpdateBookingUpcomingForBookingDoctorHandler(ILogger<UpdateBookingUpcomingForBookingDoctorHandler> logger, IBookingDoctorRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task<BookingDoctor> Handle(UpdateBookingUpcomingForBookingDoctorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingDoctor = await repository.GetAsync(request.BookingDoctorID);

            if (bookingDoctor is null)
            {
                return null;
            }

            bookingDoctor.BookingStatus = BookingStatus.Upcoming;

            await repository.UpdateAsync(bookingDoctor);

            return bookingDoctor;
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return null;
        }

    }
}

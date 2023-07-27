using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Repository.BookingDoctorRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Constants;
using Project.Common.Model;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Core.RabbitMQ;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class UpdateBookingStatusForBookingDoctorHandler : IRequestHandler<UpdateBookingStatusForBookingDoctorCommand, ObjectResult>
{
    private readonly ILogger<UpdateBookingStatusForBookingDoctorHandler> logger;
    private readonly IBookingDoctorRepository repository;
    private readonly IBus bus;

    public UpdateBookingStatusForBookingDoctorHandler(ILogger<UpdateBookingStatusForBookingDoctorHandler> logger, IBookingDoctorRepository repository, IBus bus)
    {
        this.logger = logger;
        this.repository = repository;
        this.bus = bus;
    }

    public async Task<ObjectResult> Handle(UpdateBookingStatusForBookingDoctorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingDoctor = await repository.GetAsync(request.BookingDoctorID);

            if (bookingDoctor is null)
            {
                return ApiResponse.BadRequest("Booking Doctor not found!");
            }

            bookingDoctor.BookingStatus = request.BookingStatus;
            if (bookingDoctor.BookingStatus == BookingStatus.Cancel)
            {
                await bus.SendMessageWithExchangeName<RefundEvent>(new RefundEvent
                {
                    BookingID = bookingDoctor.BookingID,
                    BookingType = 0,
                    Price = bookingDoctor.Price
                }, ExchangeConstants.PaymentService);
            }
            await repository.UpdateAsync(bookingDoctor);

            return ApiResponse.OK("Update Success.");
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }

    }
}

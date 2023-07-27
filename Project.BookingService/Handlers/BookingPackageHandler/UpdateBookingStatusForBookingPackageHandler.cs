using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Constants;
using Project.Common.Model;
using Project.Common.Response;
using Project.Core.Logger;
using Project.Core.RabbitMQ;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class UpdateBookingStatusForBookingPackageHandler : IRequestHandler<UpdateBookingStatusForBookingPackageCommand, ObjectResult>
{
    private readonly ILogger<UpdateBookingStatusForBookingPackageHandler> logger;
    private readonly IBookingPackageRepository repository;
    private readonly IBus bus;

    public UpdateBookingStatusForBookingPackageHandler(ILogger<UpdateBookingStatusForBookingPackageHandler> logger, IBookingPackageRepository repository, IBus bus)
    {
        this.logger = logger;
        this.repository = repository;
        this.bus = bus;
    }

    public async Task<ObjectResult> Handle(UpdateBookingStatusForBookingPackageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackage = await repository.GetAsync(request.BookingPackageID);

            if (bookingPackage is null)
            {
                return ApiResponse.BadRequest("Booking Package not found!");
            }

            bookingPackage.BookingStatus = request.BookingStatus;
            if (bookingPackage.BookingStatus == BookingStatus.Cancel)
            {
                await bus.SendMessageWithExchangeName<RefundEvent>(new RefundEvent
                {
                    BookingID = bookingPackage.BookingID,
                    BookingType = 1,
                    Price = bookingPackage.Price
                }, ExchangeConstants.PaymentService);
            }
            await repository.UpdateAsync(bookingPackage);

            return ApiResponse.OK("Update Success.");
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }

    }
}

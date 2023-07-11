using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Repository.BookingDoctorRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class UpdateBookingStatusForBookingDoctorHandler : IRequestHandler<UpdateBookingStatusForBookingDoctorCommand, ObjectResult>
{
    private readonly ILogger<UpdateBookingStatusForBookingDoctorHandler> logger;
    private readonly IBookingDoctorRepository repository;

    public UpdateBookingStatusForBookingDoctorHandler(ILogger<UpdateBookingStatusForBookingDoctorHandler> logger, IBookingDoctorRepository repository)
    {
        this.logger = logger;
        this.repository = repository;
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

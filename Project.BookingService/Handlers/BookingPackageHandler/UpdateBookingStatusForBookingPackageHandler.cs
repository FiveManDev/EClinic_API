using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class UpdateBookingStatusForBookingPackageHandler : IRequestHandler<UpdateBookingStatusForBookingPackageCommand, ObjectResult>
{
    private readonly ILogger<UpdateBookingStatusForBookingPackageHandler> logger;
    private readonly IBookingPackageRepository repository;
    private readonly IMapper mapper;

    public UpdateBookingStatusForBookingPackageHandler(ILogger<UpdateBookingStatusForBookingPackageHandler> logger, IBookingPackageRepository repository, IMapper mapper)
    {
        this.logger = logger;
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ObjectResult> Handle(UpdateBookingStatusForBookingPackageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackage = await repository.GetAsync(request.bookingPackageID);

            if (bookingPackage is null)
            {
                return ApiResponse.BadRequest("Booking Package not found!");
            }

            bookingPackage.BookingStatus = request.bookingStatus;

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

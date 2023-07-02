using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class DeleteBookingPackageHandler : IRequestHandler<DeleteBookingPackageCommand, ObjectResult>
{
    private readonly ILogger<DeleteBookingPackageHandler> logger;   
    private readonly IBookingPackageRepository repository;

    public DeleteBookingPackageHandler(ILogger<DeleteBookingPackageHandler> logger, IBookingPackageRepository repository, IMapper mapper)
    {
        this.logger = logger;
        this.repository = repository;
    }

    public async Task<ObjectResult> Handle(DeleteBookingPackageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackage = await repository.GetAsync(request.bookingPackageID);

            if (bookingPackage is null)
            {
                return ApiResponse.BadRequest("Booking Package not found!");
            }

            await repository.DeleteAsync(bookingPackage);

            return ApiResponse.OK("Delete Success.");
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }

    }
}

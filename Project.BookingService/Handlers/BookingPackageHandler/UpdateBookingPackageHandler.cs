using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class UpdateBookingPackageHandler : IRequestHandler<UpdateBookingPackageCommand, ObjectResult>
{
    private readonly ILogger<UpdateBookingPackageHandler> logger;
    private readonly IBookingPackageRepository repository;
    private readonly IMapper mapper;

    public UpdateBookingPackageHandler(ILogger<UpdateBookingPackageHandler> logger, IBookingPackageRepository repository, IMapper mapper)
    {
        this.logger = logger;
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<ObjectResult> Handle(UpdateBookingPackageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackage = await repository.GetAsync(request.updateBookingPackageDTO.BookingID);

            if (bookingPackage is null)
            {
                return ApiResponse.BadRequest("Booking Package not found!");
            }

            bookingPackage = mapper.Map<UpdateBookingPackageDTO, BookingPackage>(request.updateBookingPackageDTO, bookingPackage);

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

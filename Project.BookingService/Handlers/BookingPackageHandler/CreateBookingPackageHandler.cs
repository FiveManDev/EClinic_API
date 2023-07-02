using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceCommands.Commands;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class CreateBookingPackageHandler : IRequestHandler<CreateBookingPackageCommand, ObjectResult>
{
    private readonly ILogger<CreateBookingPackageHandler> logger;
    private readonly IBookingPackageRepository repository;
    private readonly IMapper mapper;

    public CreateBookingPackageHandler(IBookingPackageRepository repository, ILogger<CreateBookingPackageHandler> logger, IMapper mapper)
    {
        this.repository = repository;
        this.logger = logger;
        this.mapper = mapper;
    }

    public async Task<ObjectResult> Handle(CreateBookingPackageCommand request, CancellationToken cancellationToken)
    {
        try
        {
            BookingPackage bookingPackage = mapper.Map<BookingPackage>(request.createBookingPackageDTO);

            bookingPackage.BookingStatus = BookingStatus.Upcoming;

            await repository.CreateAsync(bookingPackage);

            return ApiResponse.OK("Create Success.");
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }

    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.BookingService.Data;
using Project.BookingService.Repository.BookingPackageRepository;
using Project.BookingServiceQueries.Queries;
using Project.Common.Paging;
using Project.Common.Response;
using Project.Core.Logger;

namespace Project.BookingService.Handlers.BookingPackageHandler;

public class GetAllBookingPackageForAdHandler : IRequestHandler<GetAllBookingPackageForAdQuery, ObjectResult>
{
    private readonly IBookingPackageRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<GetAllBookingPackageForAdHandler> logger;

    public GetAllBookingPackageForAdHandler(IBookingPackageRepository repository, IMapper mapper, ILogger<GetAllBookingPackageForAdHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ObjectResult> Handle(GetAllBookingPackageForAdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var bookingPackages = await repository.GetAllAsync();
            if (bookingPackages == null)
            {
                return ApiResponse.NotFound("Booking Packages Not Found.");
            }
            PaginationResponseHeader header = new PaginationResponseHeader();
            header.TotalCount = bookingPackages.Count;
            bookingPackages = bookingPackages
                .OrderByDescending(x => x.BookingTime)
                .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                .Take(request.PaginationRequestHeader.PageSize).ToList();

            header.PageIndex = request.PaginationRequestHeader.PageNumber;
            header.PageSize = request.PaginationRequestHeader.PageSize;

            request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(header));

            return ApiResponse.OK<List<BookingPackage>>(bookingPackages);
        }
        catch (Exception ex)
        {
            logger.WriteLogError(ex.Message);
            return ApiResponse.InternalServerError();
        }
    }
}

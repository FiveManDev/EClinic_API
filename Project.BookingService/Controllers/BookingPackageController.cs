using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingService.Dtos.BookingPackageDTOs;
using Project.BookingServiceCommands.Commands;
using Project.BookingServiceQueries.Queries;
using Project.Common.Constants;
using Project.Common.Paging;
using Project.Core.Authentication;

namespace Project.BookingService.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[Action]")]
[ApiController]
[ApiVersion("1")]
public class BookingPackageController : ControllerBase
{
    private readonly IMediator mediator;

    public BookingPackageController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookingPackage([FromForm] CreateBookingPackageDTO createBookingPackageDTO)
    {
        return await mediator.Send(new CreateBookingPackageCommand(createBookingPackageDTO));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookingPackage([FromForm] UpdateBookingPackageDTO updateBookingPackageDTO)
    {
        return await mediator.Send(new UpdateBookingPackageCommand(updateBookingPackageDTO));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookingStatusForBookingPackage(Guid bookingPackageID, BookingStatus bookingStatus)
    {
        return await mediator.Send(new UpdateBookingStatusForBookingPackageCommand(bookingPackageID, bookingStatus));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBookingPackage(Guid deleteBookingPackageID)
    {
        return await mediator.Send(new DeleteBookingPackageCommand(deleteBookingPackageID));
    }

    [HttpGet]
    public async Task<IActionResult> GetBookingPackageByID(Guid bookingPackageID)
    {
        return await mediator.Send(new GetBookingPackageByIDQuery(bookingPackageID));
    }

    //[HttpGet]
    //[CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    //public async Task<IActionResult> GetServiceByIDForAd(Guid serviceID)
    //{
    //    return await mediator.Send(new GetServiceByIDForAdQuery(serviceID));
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetAllService([FromHeader] int PageNumber, [FromHeader] int PageSize)
    //{
    //    PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
    //    return await mediator.Send(new GetAllServiceQuery(paginationRequestHeader, Response));
    //}

    [HttpGet]
    [CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    public async Task<IActionResult> GetAllBookingPackageForAd([FromHeader] int PageNumber, [FromHeader] int PageSize)
    {
        PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
        return await mediator.Send(new GetAllBookingPackageForAdQuery(paginationRequestHeader, Response));
    }

    //[HttpGet]
    //public async Task<IActionResult> SearchService([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] SearchServiceDTO searchServiceDTO)
    //{
    //    PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
    //    return await mediator.Send(new SearchServiceQuery(paginationRequestHeader, searchServiceDTO, Response));
    //}

    //[HttpGet]
    //[CustomAuthorize(Authorities = new[] { RoleConstants.Admin, RoleConstants.Supporter })]
    //public async Task<IActionResult> SearchServiceForAd([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] SearchServiceDTO searchServiceDTO)
    //{
    //    PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
    //    return await mediator.Send(new SearchServiceForAdQuery(paginationRequestHeader, searchServiceDTO, Response));
    //}

}

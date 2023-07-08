using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingServiceCommands.Commands;
using Project.BookingServiceQueries.Queries;
using Project.Common.Paging;

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
    [HttpGet]
    public async Task<IActionResult> GetAllBookingPackageForAD([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] BookingStatus BookingStatus)
    {
        PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
        return await mediator.Send(new GetAllBookingPackageForAdQuery(paginationRequestHeader, Response,BookingStatus));
    }
    [HttpGet]
    public async Task<IActionResult> GetAllBookingPackageForUser([FromHeader] int PageNumber, [FromHeader] int PageSize, [FromQuery] BookingStatus BookingStatus)
    {
        PaginationRequestHeader paginationRequestHeader = new PaginationRequestHeader { PageSize = PageSize, PageNumber = PageNumber };
        //string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
        string userId = "63da4fe0-de4d-4c8e-b8c8-ec3202c20038";
        return await mediator.Send(new GetAllBookingPackageForUserQuery(paginationRequestHeader, Response, userId,BookingStatus));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBookingPackageStatusDone(Guid BookingPackageID)
    {
        return await mediator.Send(new UpdateBookingStatusForBookingPackageCommand(BookingPackageID, BookingStatus.Done));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBookingPackageStatusCancel(Guid BookingPackageID)
    {
        return await mediator.Send(new UpdateBookingStatusForBookingPackageCommand(BookingPackageID, BookingStatus.Cancel));
    }
}

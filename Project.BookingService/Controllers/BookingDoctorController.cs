using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.BookingService.Data;
using Project.BookingServiceCommands.Commands;

namespace Project.BookingService.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[Action]")]
[ApiController]
[ApiVersion("1")]
public class BookingDoctorController : ControllerBase
{
    private readonly IMediator mediator;

    public BookingDoctorController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBookingDoctorStatusDone(Guid BookingID)
    {
        return await mediator.Send(new UpdateBookingStatusForBookingDoctorCommand(BookingID,BookingStatus.Done));
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBookingDoctorStatusCancel(Guid BookingID)
    {
        return await mediator.Send(new UpdateBookingStatusForBookingDoctorCommand(BookingID, BookingStatus.Cancel));
    }
}

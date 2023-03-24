using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;

namespace Project.CommunicateService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class RoomsController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoomsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(Guid RoomTypeID)
        {
            return await mediator.Send(new CreateRoomCommand(RoomTypeID));
        }
    }
}

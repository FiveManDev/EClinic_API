using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.CommunicateService.Commands;
using Project.CommunicateService.Dtos.VideoCallDtos;

namespace Project.CommunicateService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class VideoCallsController : ControllerBase
    {
        private readonly IMediator mediator;

        public VideoCallsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVideoCall(CreateVideoCallDtos createVideoCallDtos)
        {
            string userId = User.Claims.FirstOrDefault(claim => claim.Type == "UserID").Value;
            return await mediator.Send(new CreateVideoCallCommand(createVideoCallDtos));
        }
    }
}

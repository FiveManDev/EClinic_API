using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.NotificationService.Commands;

namespace Project.NotificationService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class MailController : ControllerBase
    {
        private readonly IMediator mediator;

        public MailController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            return await mediator.Send(new VerifyEmailCommand(email));
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email)
        {
            return await mediator.Send(new ConfirmEmailCommand(email));
        }
    }
}

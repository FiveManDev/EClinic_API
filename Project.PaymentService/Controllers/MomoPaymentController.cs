using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.PaymentService.Commands;
using Project.PaymentService.Queries;

namespace Project.PaymentService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class MomoPaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public MomoPaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentRequest(Guid BookingID)
        {
            return await mediator.Send(new GetPaymentURLQuery(Data.PaymentService.Momo, BookingID));
        }
        [HttpGet]
        public async Task<IActionResult> PaymentReturnURl()
        {
            var queryParameters = HttpContext.Request.Query;
            var url = await mediator.Send(new CreatePaymentCommand(queryParameters, Data.PaymentService.Momo));
            return Redirect(url);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.PaymentService.Commands;
using Project.PaymentService.Queries;

namespace Project.PaymentService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class VNPayPaymentController : ControllerBase
    {
        private readonly IMediator mediator;

        public VNPayPaymentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentRequest(Guid BookingID)
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await mediator.Send(new GetPaymentURLQuery(Data.PaymentService.VNPay, BookingID, ipAddress));
        }
        [HttpGet]
        public async Task<IActionResult> PaymentReturnURl()
        {
            var queryParameters = HttpContext.Request.Query;
            var url = await mediator.Send(new CreatePaymentCommand(queryParameters, Data.PaymentService.VNPay));
            return Redirect(url);
        }
    }
}


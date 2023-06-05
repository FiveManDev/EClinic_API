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
        private readonly Mediator mediator;

        public VNPayPaymentController(Mediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PaymentRequest(Guid BookingID)
        {
            string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            return await mediator.Send(new GetPaymentURLQuery(Data.PaymentService.Momo, BookingID, ipAddress));
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


using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.NotificationService.Commands;
using Project.NotificationService.Dtos;

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
        [HttpGet]
        public async Task<IActionResult> SendBill(string email)
        {
            PaymentModel paymentModel = new PaymentModel
            {
                BookingID = Guid.NewGuid(),
                PaymentAmount = 10000,
                PaymentID = Guid.NewGuid(),
                PaymentService = Data.PaymentService.Momo,
                PaymentTime = DateTime.Now,
                FullName ="Nguyen Hoang Khang",
                TransactionID = "1213244453",
            };
            return await mediator.Send(new SendBillCommand(email,paymentModel));
        }
    }
}

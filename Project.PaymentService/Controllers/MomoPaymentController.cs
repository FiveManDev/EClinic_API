using Microsoft.AspNetCore.Mvc;
using Project.PaymentService.Model;
using Project.PaymentService.MomoPayment;
using Project.PaymentService.MomoPayment.MomoPaymentSuport;

namespace Project.PaymentService.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [ApiVersion("1")]
    public class MomoPaymentController : ControllerBase
    {
        private readonly IMomoPayment momo;

        public MomoPaymentController(IMomoPayment momo)
        {
            this.momo = momo;
        }

        [HttpPost]
        public async Task<IActionResult> GetUrl(PaymentModel paymentModel)
        {
            return Ok(await momo.PaymentRequest(paymentModel));
        }
        [HttpGet]
        public IActionResult ReturnURl()
        {
            var queryParameters = HttpContext.Request.Query;

            // Create an instance of the MomoPaymentModel class
            var model = ConvertResponse.ConvertPaymentResponse(queryParameters);
            Console.WriteLine($"Partner Code: {model.PartnerCode}");
            Console.WriteLine($"Access Key: {model.AccessKey}");
            Console.WriteLine($"Request ID: {model.RequestId}");
            Console.WriteLine($"Amount: {model.Amount}");
            Console.WriteLine($"Order ID: {model.OrderId}");
            Console.WriteLine($"Order Info: {model.OrderInfo}");
            Console.WriteLine($"Order Type: {model.OrderType}");
            Console.WriteLine($"Transaction ID: {model.TransId}");
            Console.WriteLine($"Message: {model.Message}");
            Console.WriteLine($"Local Message: {model.LocalMessage}");
            Console.WriteLine($"Response Time: {model.ResponseTime}");
            Console.WriteLine($"Error Code: {model.ErrorCode}");
            Console.WriteLine($"Pay Type: {model.PayType}");
            Console.WriteLine($"Extra Data: {model.ExtraData}");
            Console.WriteLine($"Signature: {model.Signature}");
            return Redirect("https://localhost:7003/swagger/index.html");
        }
    }
}

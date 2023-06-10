using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Response;
using Project.Core.Logger;
using Project.PaymentService.Model;
using Project.PaymentService.MomoPayment;
using Project.PaymentService.Protos;
using Project.PaymentService.Queries;
using Project.PaymentService.VNPayPayment;

namespace Project.PaymentService.Handlers.PaymentHandlers
{
    public class GetPaymentURLHandler : IRequestHandler<GetPaymentURLQuery, ObjectResult>
    {
        private readonly ILogger<GetPaymentURLHandler> logger;
        private readonly IMomoPayment momoPayment;
        private readonly IVNPayPayment vNPayPayment;
        private readonly BookingService.BookingServiceClient client;

        public GetPaymentURLHandler(IConfiguration configuration, ILogger<GetPaymentURLHandler> logger, IMomoPayment momoPayment, IVNPayPayment vNPayPayment)
        {
            this.logger = logger;
            this.momoPayment = momoPayment;
            this.vNPayPayment = vNPayPayment;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:BookingServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new BookingService.BookingServiceClient(channel);
        }

        public async Task<ObjectResult> Handle(GetPaymentURLQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //var booking = await client.GetBookingAsync(new GetBookingRequest { BookingID = request.BookingID.ToString() });
                //PaymentModel paymentModel = new PaymentModel
                //{
                //    BookingID = Guid.Parse(booking.BookingID),
                //    UserID = Guid.Parse(booking.UserID),
                //    Amount = booking.Amount,
                //    Message = booking.Message
                //};
                PaymentModel paymentModel = new PaymentModel
                {
                    BookingID = Guid.Parse("63da4fe0-de4d-4c8e-b8c8-ec3202c20038"),
                    UserID = Guid.Parse("63da4fe0-de4d-4c8e-b8c8-ec3202c20038"),
                    Amount = 10000,
                    Message = "Test"
                };
                string url = "";
                switch (request.PaymentService)
                {
                    case Data.PaymentService.Momo:
                        url = await momoPayment.PaymentRequest(paymentModel);
                        break;

                    case Data.PaymentService.VNPay:
                        url = vNPayPayment.PaymentRequest(paymentModel,request.IpAddress);
                        break;
                    default:
                        url = null;
                        break;
                }
                if(url == null)
                {
                    throw new Exception("Get payment url error");
                }
                return ApiResponse.OK(url);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}

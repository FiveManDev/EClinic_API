using Grpc.Net.Client;
using MediatR;
using Project.Core.Logger;
using Project.PaymentService.Commands;
using Project.PaymentService.Data;
using Project.PaymentService.Model;
using Project.PaymentService.MomoPayment;
using Project.PaymentService.Protos;
using Project.PaymentService.Repository.PaymentRepositories;
using Project.PaymentService.VNPayPayment;

namespace Project.PaymentService.Handlers.PaymentHandlers
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, string>
    {
        private readonly ILogger<CreatePaymentHandler> logger;
        private readonly IMomoPayment momoPayment;
        private readonly IVNPayPayment vNPayPayment;
        private readonly IPaymentRepository paymentRepository;
        private readonly string clientAddress;
        private readonly BookingService.BookingServiceClient client;

        public CreatePaymentHandler(IConfiguration configuration, ILogger<CreatePaymentHandler> logger, IMomoPayment momoPayment, IVNPayPayment vNPayPayment, IPaymentRepository paymentRepository)
        {
            this.logger = logger;
            this.momoPayment = momoPayment;
            this.vNPayPayment = vNPayPayment;
            this.paymentRepository = paymentRepository;
            clientAddress = configuration.GetValue<string>("ClinentUrl");
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            GrpcChannel channel = GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcSettings:BookingServiceUrl"), new GrpcChannelOptions { HttpHandler = httpHandler });
            client = new BookingService.BookingServiceClient(channel);
        }

        public async Task<string> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string url = null;
                PaymentResult paymentResult = null;
                switch (request.PaymentService)
                {

                    case Data.PaymentService.Momo:
                        paymentResult = momoPayment.PaymentConfirm(request.QueryParameters);
                        break;

                    case Data.PaymentService.VNPay:
                        paymentResult = vNPayPayment.PaymentConfirm(request.QueryParameters);
                        break;
                    default:
                        paymentResult = null;
                        break;
                }
                if (paymentResult == null)
                {
                    return null;
                }
                var type = paymentResult.PaymentType;
                if(type == "BookingPackage")
                {
                    var updateResult = await client.UpdateBookingPackageAsync(new UpdateBookingPackageRequest { BookingPackageID = paymentResult.BookingID.ToString() });
                    url = $"{clientAddress}/services/{updateResult.UserID}?bookingId={paymentResult.BookingID}";
                }
                if (type == "BookingDoctor")
                {
                    var updateResult = await client.UpdateBookingDoctorAsync(new UpdateBookingDoctorRequest { BookingDoctorID = paymentResult.BookingID.ToString() });
                    url = $"{clientAddress}/doctors/{updateResult.UserID}?bookingId={paymentResult.BookingID}";
                }
                Payment payment = new Payment
                {
                    BookingID = paymentResult.BookingID,
                    PaymentAmount = paymentResult.Amount,
                    PaymentService = request.PaymentService,
                    PaymentTime = paymentResult.PaymentTime,
                    TransactionID = paymentResult.TransactionID,
                    UserID = paymentResult.UserID,
                    OrderID = paymentResult.OrderID
                };
                var result = await paymentRepository.CreateAsync(payment);
                if (!result)
                {
                    return clientAddress;
                }
                return url;
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return null;
            }
        }
    }
}

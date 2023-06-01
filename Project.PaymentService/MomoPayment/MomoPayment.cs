using Newtonsoft.Json.Linq;
using Project.PaymentService.Model;
using Project.PaymentService.MomoPayment.MomoPaymentConfiguration;
using Project.PaymentService.MomoPayment.MomoPaymentModel;

namespace Project.PaymentService.MomoPayment
{
    public class MomoPayment : IMomoPayment
    {
        private readonly MomoInformation MomoInformation;

        public MomoPayment(IConfiguration configuration)
        {
            MomoInformation = configuration.GetSection("MomoConnectionInformation").Get<MomoInformation>();
        }

        public async Task<string> PaymentRefund(PaymentModel PaymentModel)
        {
            string router = "pay/refund";
            var OrderInfo = PaymentModel.Message.ToString();
            var Amount = PaymentModel.Amount.ToString();
            var ExtraData = PaymentModel.BookingTime.ToString();
            string orderid = PaymentModel.UserID.ToString();
            string requestId = PaymentModel.BookingID.ToString();
            string rawHash = "partnerCode=" +
               MomoInformation.MomoPartnerCode + "&requestId=" +
               requestId + "&amount=" +
               Amount + "&orderId=" +
               orderid + "&orderInfo=" +
               OrderInfo + "&returnUrl=" +
               MomoInformation.ReturnUrl + "&notifyUrl=" +
               MomoInformation.NotifyUrl + "&extraData=" +
               ExtraData;
            MoMoSecurity crypto = new MoMoSecurity();
            string signature = crypto.signSHA256(rawHash, MomoInformation.MomoSerectkey);
            var message = new
            {
                accessKey = MomoInformation.MomoAccessKey,
                partnerCode = MomoInformation.MomoPartnerCode,
                requestType = "captureMoMoWallet",
                notifyUrl = MomoInformation.NotifyUrl,
                returnUrl = MomoInformation.ReturnUrl,
                orderId = orderid,
                amount = Amount,
                orderInfo = OrderInfo,
                requestId = requestId,
                extraData = ExtraData,
                signature = signature
            };
            var responseFromMomo = await MomoPaymentMethod.SendPaymentRequest(MomoInformation.Endpoint, router, message);
            JObject jmessage = JObject.Parse(responseFromMomo);
            if (jmessage.GetValue("payUrl") != null)
            {
                return jmessage.GetValue("payUrl").ToString();
            }
            return null;
        }

        public async Task<string> PaymentRequest(PaymentModel PaymentModel)
        {
            string router = "gw_payment/transactionProcessor";
            var OrderInfo = PaymentModel.Message.ToString();
            var Amount = PaymentModel.Amount.ToString();
            var ExtraData = PaymentModel.BookingTime.ToString();
            string orderid = PaymentModel.UserID.ToString();
            string requestId = PaymentModel.BookingID.ToString();
            string rawHash = "partnerCode=" +
                MomoInformation.MomoPartnerCode + "&accessKey=" +
                MomoInformation.MomoAccessKey + "&requestId=" +
                requestId + "&amount=" +
                Amount + "&orderId=" +
                orderid + "&orderInfo=" +
                OrderInfo + "&returnUrl=" +
                MomoInformation.ReturnUrl + "&notifyUrl=" +
                MomoInformation.NotifyUrl + "&extraData=" +
                ExtraData;
            MoMoSecurity crypto = new MoMoSecurity();
            string signature = crypto.signSHA256(rawHash, MomoInformation.MomoSerectkey);
            var message = new
            {
                accessKey = MomoInformation.MomoAccessKey,
                partnerCode = MomoInformation.MomoPartnerCode,
                requestType = "captureMoMoWallet",
                notifyUrl = MomoInformation.NotifyUrl,
                returnUrl = MomoInformation.ReturnUrl,
                orderId = orderid,
                amount = Amount,
                orderInfo = OrderInfo,
                requestId = requestId,
                extraData = ExtraData,
                signature = signature
            };
            var responseFromMomo = await MomoPaymentMethod.SendPaymentRequest(MomoInformation.Endpoint, router, message);
            JObject jmessage = JObject.Parse(responseFromMomo);
            if (jmessage.GetValue("payUrl") != null)
            {
                return jmessage.GetValue("payUrl").ToString();
            }
            return null;
        }

        public Task<string> TransactionQuery(PaymentModel PaymentModel)
        {
            throw new NotImplementedException();
        }
    }
}

using Project.PaymentService.MomoPayment.MomoPaymentModel;

namespace Project.PaymentService.MomoPayment.MomoPaymentSuport
{
    public class ConvertResponse
    {
        public static MomoResponseModel ConvertPaymentResponse(IQueryCollection query)
        {
            var model = new MomoResponseModel
            {
                PartnerCode = query["partnerCode"],
                AccessKey = query["accessKey"],
                RequestId = query["requestId"],
                Amount = int.Parse(query["amount"]),
                OrderId = query["orderId"],
                OrderInfo = query["orderInfo"],
                OrderType = query["orderType"],
                TransId = long.Parse(query["transId"]),
                Message = query["message"],
                LocalMessage = query["localMessage"],
                ResponseTime = DateTime.Parse(query["responseTime"]),
                ErrorCode = int.Parse(query["errorCode"]),
                PayType = query["payType"],
                ExtraData = query["extraData"],
                Signature = query["signature"]
            };
            return model;
        }
    }
}

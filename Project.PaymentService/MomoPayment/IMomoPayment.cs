using Project.PaymentService.Model;

namespace Project.PaymentService.MomoPayment
{
    public interface IMomoPayment
    {
        Task<string> PaymentRequest(PaymentModel PaymentModel);
        Task<string> PaymentRefund(PaymentModel PaymentModel);
        Task<string> TransactionQuery(PaymentModel PaymentModel);
    }
}

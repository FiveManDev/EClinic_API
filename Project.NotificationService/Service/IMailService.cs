using Project.NotificationService.Dtos;

namespace Project.NotificationService.Service
{
    public interface IMailService
    {
        void VerifyEmail(string email, string code);
        void ConfirmEmail(string email, string code);
        void SendBill(string email, PaymentModelData paymentModel);
        void SendAccount(string email, AccountDtos account);
    }
}

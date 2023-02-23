using Project.NotificationService.Dtos;

namespace Project.NotificationService.Service
{
    public interface IMailService
    {
        void VerifyEmail(string email, string code);
        void ConfirmEmail(string email, string code);
    }
}

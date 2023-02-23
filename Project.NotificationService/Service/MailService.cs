using Project.Core.Logger;
using Project.NotificationService.Dtos;
using System.Net;
using System.Net.Mail;

namespace Project.NotificationService.Service
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> logger;
        private readonly IConfiguration configuration;
        private readonly MailInformation mailInformation = new MailInformation();
        public MailService(ILogger<MailService> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
            configuration.GetSection("MailConnectionInformation").Bind(mailInformation);
        }

        public void ConfirmEmail(string email, string code)
        {
            var mailName = email.Substring(0, email.IndexOf("@"));
            var mailModel = new MailModel
            {
                EmailTo = email,
                Subject = "Confirm your email address",
                Body = $"Welcome {mailName.ToLower()}!" +
                $"<br/><br/>" +
                $"Thanks for signing up with {mailInformation.MailTile}!" +
                $"<br/><b>{code}</b> is your {mailInformation.MailTile} verification." +
                $" <br/>" +
                $"Thank you," +
                $" <br/>" +
                $"{mailInformation.MailTile} account group"
            };
            SendMail(mailModel);
        }

        public void VerifyEmail(string email, string code)
        {
            var mailName = email.Substring(0, email.IndexOf("@"));
            var mailModel = new MailModel
            {
                EmailTo = email,
                Subject = $"Reset {mailInformation.MailTile} account password",
                Body = $"Hello {mailName.ToLower()}!" +
                $"<br/><br/>" +
                $"Please use this code to reset the password for your {mailInformation.MailTile} account {email}" +
                $"<br/>Here is your code: <b>{code}</b>." +
                $" <br/>" +
                $"Thank you," +
                $" <br/>" +
                $"{mailInformation.MailTile} account group"

            };
            SendMail(mailModel);
        }

        private void SendMail(MailModel mailModel)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mailInformation.Mail, mailInformation.MailTile);
                mailMessage.To.Add(new MailAddress(mailModel.EmailTo));
                mailMessage.Subject = mailModel.Subject;
                mailMessage.Body = mailModel.Body;

                if (mailModel.CC != null)
                {
                    foreach (var cc in mailModel.CC)
                    {
                        mailMessage.CC.Add(cc);
                    }
                }
                if (mailModel.Attachments != null)
                {
                    foreach (var attachment in mailModel.Attachments)
                    {
                        string fileName = Path.GetFileName(attachment.FileName);
                        mailMessage.Attachments.Add(new Attachment(attachment.OpenReadStream(), fileName));
                    }
                }
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = mailInformation.Host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(mailInformation.Mail, mailInformation.MailAppPassword);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = Int32.Parse(mailInformation.Port);
                smtp.Send(mailMessage);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
            }
        }
    }
}

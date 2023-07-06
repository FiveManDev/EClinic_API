using MassTransit.Internals.GraphValidation;
using Project.Core.Logger;
using Project.NotificationService.Dtos;
using System.ComponentModel;
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

        public void SendBill(string email, PaymentModel paymentModel)
        {
            try
            {
                var mailName = email.Substring(0, email.IndexOf("@"));
                var mailModel = new MailModel
                {
                    EmailTo = email,
                    Subject = $"Reset {mailInformation.MailTile} account password",
                    Body = @"<html>
<head>
    <style>
        
        body {
            background-color: #f6f9f8;
            font-family: 'Roboto', sans-serif;
        }

        a {
            color: #0e7aea;
            text-decoration: none;
        }

        h6 {
            color: #9aa3ab;
            font-weight: 300;
            line-height: 15px;
        }

        h5 {
            color: #99a1aa;
            font-weight: 300;
        }

        h4 {
            font-weight: 300;
            font-size: 13px;
            color: #97a2ad
        }

        h3 {
            color: #58636a;
            font-weight: 500;
        }

        .container {
            width: 50%;
            height: 40%;
            min-width: 636px;
            min-height: 456px;
            margin: auto;
            margin-top: 10%;
            overflow: hidden;
            border-radius: 5px 5px 5px 5px;
            -webkit-box-shadow: 0px 5px 21px 0px rgba(128,128,128,0.2);
            -moz-box-shadow: 0px 5px 21px 0px rgba(128,128,128,0.2);
            box-shadow: 0px 5px 21px 0px rgba(128,128,128,0.2);
        }

        .left {
            background-color: #1882ef;
            width: 39%;
            height: 457px;
            border-radius: 5px 0 0 5px;
            float: left;
            color: #ffffff;
        }

        .info-box {
            margin-top: 35px;
            margin-left: 35px;
            margin-right: 35px;
        }

        .receipt {
            font-weight: 300;
            font-size: 15px;
            line-height: 26px;
            padding-top: 10px;
            padding-bottom: 15px;
            border-bottom: 1px solid #3895f4;
            height: 15%;
        }

            .receipt > span {
                font-weight: 500;
                font-size: 21px;
            }

        .entry {
            border-bottom: 1px solid #3895f4;
            height: 15%;
            overflow: hidden;
            padding-top: 15px;
        }

            .entry > p {
                font-weight: 300;
                font-size: 13px;
                line-height: 26px;
                margin-top: 0px !important;
                float: left;
            }

            .entry > i {
                margin-top: 4px;
                margin-right: 13px;
                float: left;
                color: #b4d8fc;
            }

        span {
            font-weight: 500;
            font-size: 16px;
        }

        .entry:last-child {
            border-bottom: none;
        }

        .right {
            background-color: #fefefe;
            width: 61%;
            height: 100%;
            float: left;
            border-radius: 0 5px 5px 0;
        }

        .content {
            margin-top: 50px;
            margin-left: 40px;
            margin-right: 40px;
        }

        .header {
            overflow: hidden;
            border-bottom: 1px solid #d7e2e7;
            height: 50px;
        }

            .header > img {
                width: 100px;
                float: left;
            }

            .header > h4 {
                text-align: right;
                margin-top: 10px;
            }

        .main {
            margin-top: 35px;
        }

        .message {
            margin-top: 40px;
        }

            .message > p {
                font-weight: 300;
                font-size: 15px;
                color: #7a838d;
                line-height: 30px;
            }

            .message > h6 {
                margin-top: 10px;
            }

        .footer {
            overflow: hidden;
            border-top: 1px solid #d7e2e7;
            margin-top: 40px;
            padding-top: 30px;
        }

            .footer > a {
                font-size: 13px;
                font-weight: 500;
                float: left;
            }

            .footer > h6 {
                color: #7a838d;
                text-align: right;
                margin-top: 0px !important;
            }
    </style>
</head>
<body>
    <html>
    <head>
        <title>Paypal checkout</title>
        <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/simple-line-icons/2.3.2/css/simple-line-icons.css"">
    </head>
    <body>
        <div class=""container"">
            <div class=""left"">
                <div class=""info-box"">
                    <div class=""receipt"">
                        Receipt for <br> <span>Eclinic</span>
                    </div>
                    <div class=""entry"">
                        <i class=""icon-wallet"" aria-hidden=""true""></i>
                        <p>Amount:<br><span>$20.00 USD</span></p>
                    </div>
                    <div class=""entry"">
                        <i class=""icon-calendar"" aria-hidden=""true""></i>
                        <p>Date:<br><span>Nov 5</span></p>
                    </div>
                    <div class=""entry"">
                        <i class=""icon-star"" aria-hidden=""true""></i>
                        <p>Issuer:<br><span>Dribbble</span></p>
                    </div>
                    <div class=""entry"">
                        <i class=""icon-notebook"" aria-hidden=""true""></i>
                        <p>Confirmation Nr:<br><span>0YX123580219G</span></p>
                    </div>
                </div>
            </div>
            <div class=""right"">
                <div class=""content"">
                    <div class=""header"">
                        <img src=""https://www.paypalobjects.com/webstatic/mktg/Logo/pp-logo-200px.png"">
                        <h4>Oct 18, 2015   08:30:57   PDT</h4>
                    </div>
                    <div class=""main"">
                        <h3>Dribbble Pro Account (1 year)</h3>
                        <h5>Total: $20.00 USD</h5>
                    </div>
                    <div class=""message"">
                        <p>Hello Ennio,</br>You sent a payment of $20.00 USD to Dribbble (<a href=""mailto:paypal@dribbble.com"">paypal@dribbble.com</a>)</p>
                        <h6>It may take a few moments for this</br>transaction to appear in your account.</h6>
                    </div>
                    <div class=""footer"">
                        <a href=""#"">www.paypal.com/help</a>
                        <h6>Invoice ID: 108165</h6>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>
</body>
</html>"
                };
                SendMail(mailModel);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
            }
        }
    }
}

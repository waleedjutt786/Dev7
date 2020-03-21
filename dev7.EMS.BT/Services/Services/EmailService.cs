using dev7.EMS.Model;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using dev7.EMS.Services.ServiceContracts;
using dev7.EMS.Domain.SMTPDE;

namespace dev7.EMS.Services.Services
{
    public class EmailService : IEmailService
    {
        //Use the following link to setup google account for email sending
        //http://stackoverflow.com/questions/29465096/how-to-send-an-e-mail-with-c-sharp-through-gmail

        #region Send Email

        public bool SendEmail(EmailModel emailModel)
        {
            var smtpClient = CreateSmtpClient();
            var msg = CreateMailMessage(emailModel);
            PrepareMailRecepiants(emailModel, msg);

            smtpClient.Send(msg);

            return true;
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="emailModel">The email model.</param>
        /// <param name="completed">Send Success Call back delegate.</param>
        /// <param name="token"></param>
        public void SendEmailAsync(EmailModel emailModel, SendCompletedCallback completed, string token)
        {
            var smtpClient = CreateSmtpClient();
            var msg = CreateMailMessage(emailModel);
            PrepareMailRecepiants(emailModel, msg);

            smtpClient.SendCompleted += new SendCompletedEventHandler(completed);
            smtpClient.SendAsync(msg, token);
        }

        public void SendEmailAsync(MailMessage mailMessage, SendCompletedCallback completed, string token, SMTPDE SMTP)
        {
            var smtpClient = CreateSmtpClient();
            smtpClient.Host = SMTP.Host;
            smtpClient.Port = SMTP.Port;
            smtpClient.Credentials = new NetworkCredential(SMTP.User,
                SMTP.Password);

            smtpClient.SendCompleted += new SendCompletedEventHandler(completed);
            smtpClient.SendAsync(mailMessage, token);
        }

        public void SendEmail(MailMessage mailMessage)
        {
            var smtpClient = CreateSmtpClient();
            //smtpClient.SendCompleted += new SendCompletedEventHandler(completed);
            smtpClient.Send(mailMessage);
        }

        private static void AddEmailAddresses(string emailAddresses, MailAddressCollection emailList)
        {
            var emails = emailAddresses.Split(';');
            foreach (var email in emails)
            {
                emailList.Add(email);
            }
        }

        private static void PrepareMailRecepiants(EmailModel emailModel, MailMessage msg)
        {
            if (string.IsNullOrWhiteSpace(emailModel.To))
                throw new Exception("Invalid recipient email address.");

            //Add To Email Address(es)
            AddEmailAddresses(emailModel.To, msg.To);

            //Add CC Email Address(es)
            if (!string.IsNullOrWhiteSpace(emailModel.CC)) AddEmailAddresses(emailModel.CC, msg.CC);

            //Add Default BCC Email Address(es)
            if (!string.IsNullOrWhiteSpace(EmailConfiguration.DefaultCcEmail)) AddEmailAddresses(EmailConfiguration.DefaultCcEmail, msg.Bcc);
        }

        private static MailMessage CreateMailMessage(EmailModel emailModel)
        {
            var msg = new MailMessage
            {
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                From = new MailAddress(EmailConfiguration.FromEmail, EmailConfiguration.FromTitle),
                Subject = emailModel.Subject,
                Body = emailModel.Message,
                Priority = MailPriority.High
            };
            return msg;
        }

        private static SmtpClient CreateSmtpClient()
        {
            var smtpClient = new SmtpClient
            {
                UseDefaultCredentials = EmailConfiguration.UseDefaultCredentials,
                Host = EmailConfiguration.SmtpHost,
                Port = EmailConfiguration.Port,
                EnableSsl = EmailConfiguration.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(EmailConfiguration.FromEmail, EmailConfiguration.FromEmailPassword),
                Timeout = EmailConfiguration.Timeout
            };
            return smtpClient;
        }

        #endregion Send Email
    }
}

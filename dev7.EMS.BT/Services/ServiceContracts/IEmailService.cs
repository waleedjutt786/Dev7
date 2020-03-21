using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using dev7.EMS.Model;
using dev7.EMS.Domain.SMTPDE;

namespace dev7.EMS.Services.ServiceContracts
{
    public delegate void SendCompletedCallback(object sender, AsyncCompletedEventArgs e);
    public interface IEmailService
    {
        bool SendEmail(EmailModel emailModel);

        void SendEmailAsync(EmailModel emailModel, SendCompletedCallback completed, string token);

        void SendEmailAsync(MailMessage mailMessage, SendCompletedCallback completed, string token, SMTPDE SMTP);
        void SendEmail(MailMessage mailMessage);
    }
}

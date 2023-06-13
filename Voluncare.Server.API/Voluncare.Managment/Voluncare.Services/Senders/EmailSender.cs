using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Services.Interfaces;

namespace Voluncare.Services.Senders
{
    public class EmailSender : IEmailSender
    {
        private readonly string senderEmail;
        private readonly string senderPassword;
        private readonly string smptHost;
        private readonly int smptPort;

        public EmailSender(IConfiguration configuration)
        {
            senderEmail = configuration["EmailNotification:Email"];
            senderPassword = configuration["EmailNotification:Password"];
            smptHost = configuration["EmailNotification:SMTPHost"];
            smptPort = int.Parse(configuration["EmailNotification:SMTPPort"]);
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient(this.smptHost, this.smptPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(this.senderEmail, this.senderPassword)
            };

            return client.SendMailAsync(
                new MailMessage(from: this.senderEmail,
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}

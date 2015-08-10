using System.Net;
using System.Net.Mail;

namespace Ap.EmailSender
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpSettings _config;

        public SmtpService(SmtpSettings config)
        {
            _config = config;
        }

        public void Send(string[] recipients, string subject, string body, string[] attachments = null)
        {
            var smtp = new SmtpClient
            {
                Host = _config.Host,
                Port = _config.Port,
                EnableSsl = _config.EnableSsl,
                UseDefaultCredentials = _config.UseDefaultCredentials
            };

            if (!smtp.UseDefaultCredentials)
            {
                smtp.Credentials = new NetworkCredential(_config.User, _config.Password);
            }

            var mail = new MailMessage
            {
                From = new MailAddress(_config.From),
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            };

            foreach (string to in recipients)
            {
                mail.To.Add(new MailAddress(to));
            }

            if (attachments != null)
            {
                foreach (string fileName in attachments)
                {
                    var attachment = new Attachment(fileName);
                    mail.Attachments.Add(attachment);
                }
            }

            smtp.Send(mail);
        }
    }
}
using MailKit.Net.Smtp;
using MimeKit;
using System.Collections.Generic;
using System.Net.Mail;

namespace Bai06.Services
{
    public class SmtpService
    {
        // Send mail
        public void Send(
            string from,
            string password,
            string to,
            string subject,
            string body,
            List<string> attachments)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(from, from));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            var builder = new BodyBuilder();
            builder.TextBody = body;

            if (attachments != null)
            {
                foreach (var file in attachments)
                {
                    builder.Attachments.Add(file);
                }
            }

            message.Body = builder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(from, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

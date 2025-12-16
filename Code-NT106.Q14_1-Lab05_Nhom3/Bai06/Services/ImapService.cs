using Bai06.Models;
using MailKit;
using MailKit.Net.Imap;
using System.Collections.Generic;
using System.Net.Mail;

namespace Bai06.Services
{
    public class ImapService
    {
        private ImapClient client;

        // Connect
        public void Connect(string email, string password)
        {
            client = new ImapClient();
            client.Connect("imap.gmail.com", 993, true);
            client.Authenticate(email, password);
        }

        // Get inbox emails
        public List<EmailItem> GetInbox(int limit)
        {
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            var emails = new List<EmailItem>();
            int count = inbox.Count;

            for (int i = count - 1; i >= 0 && emails.Count < limit; i--)
            {
                var msg = inbox.GetMessage(i);

                emails.Add(new EmailItem
                {
                    Index = i,
                    From = msg.From.ToString(),
                    Subject = msg.Subject,
                    Date = msg.Date.DateTime,
                    Body = msg.TextBody ?? msg.HtmlBody
                });
            }

            return emails;
        }

        // Disconnect
        public void Disconnect()
        {
            client.Disconnect(true);
        }
    }
}

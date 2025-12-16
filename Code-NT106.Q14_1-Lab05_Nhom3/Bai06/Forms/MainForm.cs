using Bai06;
using Bai06.Models;
using Bai06.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai06.Forms
{
    public partial class MainForm : Form
    {
        private string email;
        private string password;
        private ImapService imap;
        private List<EmailItem> emails;

        public MainForm(string email, string password)
        {
            InitializeComponent();
            this.email = email;
            this.password = password;
            LoadInbox();
        }

        // Load inbox
        private void LoadInbox()
        {
            imap = new ImapService();
            imap.Connect(email, password);

            emails = imap.GetInbox(20);

            listViewInbox.Items.Clear();

            foreach (var mail in emails)
            {
                var item = new ListViewItem(mail.From);
                item.SubItems.Add(mail.Subject);
                item.SubItems.Add(mail.Date.ToString());
                listViewInbox.Items.Add(item);
            }
        }

        // Read mail
        private void listViewInbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewInbox.SelectedIndices.Count == 0) return;

            var mail = emails[listViewInbox.SelectedIndices[0]];
            txtFrom.Text = mail.From;
            txtSubject.Text = mail.Subject;
            txtBody.Text = mail.Body;
        }

        // Reply
        private void btnReply_Click(object sender, EventArgs e)
        {
            if (listViewInbox.SelectedIndices.Count == 0) return;

            var mail = emails[listViewInbox.SelectedIndices[0]];
            new ComposeForm(email, password, mail.From, "Re: " + mail.Subject).Show();
        }

        // New mail
        private void btnNew_Click(object sender, EventArgs e)
        {
            new ComposeForm(email, password).Show();
        }
    }
}

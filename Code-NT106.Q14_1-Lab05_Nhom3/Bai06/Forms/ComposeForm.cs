using Bai06.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bai06.Forms
{
    public partial class ComposeForm : Form
    {
        private string email;
        private string password;
        private List<string> attachments = new List<string>();

        public ComposeForm(string email, string password, string to = "", string subject = "")
        {
            InitializeComponent();
            this.email = email;
            this.password = password;

            txtTo.Text = to;
            txtSubject.Text = subject;
        }

        // Attach file
        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    attachments.Add(dialog.FileName);
                    listAttachments.Items.Add(dialog.FileName);
                }
            }
        }

        // Send mail
        private void btnSend_Click(object sender, EventArgs e)
        {
            var smtp = new SmtpService();
            smtp.Send(
                email,
                password,
                txtTo.Text,
                txtSubject.Text,
                txtBody.Text,
                attachments
            );

            Close();
        }
    }
}

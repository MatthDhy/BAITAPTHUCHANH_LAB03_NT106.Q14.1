using Bai06;
using Bai06.Services;
using System;
using System.Windows.Forms;

namespace Bai06.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var imap = new ImapService();

            try
            {
                imap.Connect(txtEmail.Text, txtPassword.Text);
                Hide();
                new MainForm(txtEmail.Text, txtPassword.Text).Show();
            }
            catch
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}

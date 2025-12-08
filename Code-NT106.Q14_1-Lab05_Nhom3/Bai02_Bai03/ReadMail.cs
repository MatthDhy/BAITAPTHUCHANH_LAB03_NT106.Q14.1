using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Net.Pop3;

namespace Bai02_Bai03
{
    public partial class ReadMail : Form
    {
        public ReadMail()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string protocol = cboProtocol.SelectedItem == null ? "" : cboProtocol.SelectedItem.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng nhập Email!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập Password!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(protocol))
                {
                    MessageBox.Show("Vui lòng chọn giao thức (IMAP hoặc POP)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lvMail.Items.Clear();

                if (protocol == "IMAP")
                    LoadMail_IMAP(email, password);
                else
                    LoadMail_POP(email, password);

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadMail_IMAP(string email, string password)
        {
            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect("imap.gmail.com", 993, true);
                    client.Authenticate(email, password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    int total = inbox.Count;
                   

                    int limit = Math.Min(10, total); 
                   

                    lvMail.Items.Clear();

                    // Duyệt từ mới nhất → cũ dần
                    for (int i = total - 1; i >= total - limit; i--)
                    {
                        var message = inbox.GetMessage(i);

                        string subject = message.Subject ?? "(No subject)";
                        string from = message.From.ToString();
                        string date = message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");

                        var item = new ListViewItem(subject);
                        item.SubItems.Add(from);
                        item.SubItems.Add(date);

                        lvMail.Items.Add(item);
                    }

                    client.Disconnect(true);
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("IMAP Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMail_POP(string email, string password)
        {
            using (var client = new Pop3Client())
            {
                try
                {
                    client.Connect("pop.gmail.com", 995, true);
                    client.Authenticate(email, password);

                    int total = client.Count;
                    int limit = Math.Min(10, total);

                    lvMail.Items.Clear();

                    // Duyệt mail mới nhất → cũ dần
                    for (int i = total - 1; i >= total - limit; i--)
                    {
                        var message = client.GetMessage(i);

                        string subject = message.Subject ?? "(No subject)";
                        string from = message.From.ToString();
                        string date = message.Date.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");

                        var item = new ListViewItem(subject);
                        item.SubItems.Add(from);
                        item.SubItems.Add(date);

                        lvMail.Items.Add(item);
                    }

                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("POP3 Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void ReadMail_Load(object sender, EventArgs e)
        {
            lvMail.View = View.Details;
            lvMail.FullRowSelect = true;
            lvMail.GridLines = true;

            lvMail.Columns.Add("Email", 350);
            lvMail.Columns.Add("From", 200);
            lvMail.Columns.Add("Thời gian", 200);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            lvMail.Items.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cboProtocol.SelectedIndex = -1;
            txtEmail.Focus();

            MessageBox.Show("Đã logout thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}

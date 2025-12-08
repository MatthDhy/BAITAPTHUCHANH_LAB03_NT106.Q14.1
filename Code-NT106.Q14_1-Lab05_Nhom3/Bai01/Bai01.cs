using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Bai01
{
    public partial class Bai01 : Form
    {

        public Bai01()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string SMTPHost = "smtp.gmail.com"; // Địa chỉ SMTP của Gmail
            int SMTPPort = 587; // Port SMTP của Gmail
            string username = "24521358@gm.uit.edu.vn";
            string password = "nvem ntfu myfp nnbi";
            string from = txtFrom.Text.Trim();
            string to = txtTo.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string Body = txtBody.Text.Trim();
            string SendName = txtSendName.Text.Trim();
            string ReceiveName = txtReceiveName.Text.Trim();

            if (string.IsNullOrEmpty(to))
            {
                MessageBox.Show("Vui lòng nhập người nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(subject))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSubject.Focus();
                return;
            }
            if (string.IsNullOrEmpty(Body))
            {
                MessageBox.Show("Vui lòng nhập nội dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBody.Focus();
                return;
            }
            try
            {
                var client = new SmtpClient();
                client.Connect(SMTPHost, SMTPPort, SecureSocketOptions.StartTls); // Kết nối với STARTTLS

                client.Authenticate(username, password); // Xác thực bằng email và mật khẩu ứng dụng

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(SendName, from)); // Địa chỉ email người gửi
                message.To.Add(new MailboxAddress(ReceiveName, to)); // Địa chỉ email người nhận
                message.Subject = subject;
                message.Body = new TextPart("plain") // Gửi dưới dạng plain text
                {
                    Text = Body
                };

                client.Send(message); // Gửi email
                client.Disconnect(true); // Ngắt kết nối
                client.Dispose(); // Giải phóng tài nguyên

                MessageBox.Show("Email sent successfully!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information); // Thông báo gửi thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message); // Thông báo lỗi
            }
        }

        private void Bai01_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(() => txtTo.Focus()));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtSubject.Clear();
            txtBody.Clear();
            txtSubject.Focus();
        }
    }
}

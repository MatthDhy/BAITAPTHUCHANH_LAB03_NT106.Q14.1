using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class FormClient: Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string portText = txtPort.Text.Trim();
            string msg = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(portText))
            {
                MessageBox.Show("Vui lòng nhập IP và Port!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(portText, out int port))
            {
                MessageBox.Show("Giá trị port phải là một số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (port < 1 || port > 65535)
            {
                MessageBox.Show("Giá trị port phải nằm trong khoảng 1 đến 65535!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                MessageBox.Show("Vui lòng nhập nội dung tin nhắn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {

                using (UdpClient udpClient = new UdpClient())
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(msg);
                    udpClient.Send(bytes, bytes.Length, ip, port);
                }
                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending: " + ex.Message);
            }
        }
    }
}

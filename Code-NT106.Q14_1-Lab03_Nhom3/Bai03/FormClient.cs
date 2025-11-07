using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Bai03
{
    public partial class FormClient : Form
    {
        TcpClient client;
        NetworkStream stream;

        public FormClient()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIPAdress.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                client = new TcpClient();
                client.Connect(IPAddress.Parse(ip), port);

                stream = client.GetStream();
                MessageBox.Show("✅ Kết nối thành công đến server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Không kết nối được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client == null || stream == null)
            {
                MessageBox.Show("Bạn chưa kết nối đến Server!");
                return;
            }

            if (txtMessage.Text.Trim() == "")
                return;

            byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text + "\n");
            stream.Write(data, 0, data.Length);

            txtMessage.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }

            if (client != null)
            {
                client.Close();
                client = null;
            }
            MessageBox.Show("⛔ Đã ngắt kết nối");
        }

    }
}

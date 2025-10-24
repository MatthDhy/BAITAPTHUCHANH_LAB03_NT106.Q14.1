using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class FormServer: Form
    {
        Thread thServer;
        bool isRunning = false;
        UdpClient udpServer;
        public FormServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập số cổng (port) trước khi Listen!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Giá trị port phải là một số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (port < 1 || port > 65535)
            {
                MessageBox.Show("Giá trị port phải nằm trong khoảng 1 đến 65535!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isRunning = true;
            thServer = new Thread(ServerThread);
            thServer.IsBackground = true; 
            thServer.Start();
            btnListen.Enabled = false;
            MessageBox.Show($"Server started, ready to listen on port {port}...","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);



        }
        private void ServerThread()
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                udpServer = new UdpClient(port);
                

                while (isRunning)
                {
                    if (udpServer.Available > 0)
                    {
                        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                        byte[] data = udpServer.Receive(ref remoteEP);
                        string message = Encoding.UTF8.GetString(data);
                        listMessage.Items.Add($"{remoteEP.Address}: {message}");
                        listMessage.TopIndex = listMessage.Items.Count - 1;
                    }
                    Thread.Sleep(50);
                }

            }
            catch (SocketException)
            {

            }
            catch (ObjectDisposedException) { }
        }
        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            if (udpServer != null)
                udpServer.Close();

            if (thServer != null && thServer.IsAlive)
                thServer.Join(200);
        }
    }
}

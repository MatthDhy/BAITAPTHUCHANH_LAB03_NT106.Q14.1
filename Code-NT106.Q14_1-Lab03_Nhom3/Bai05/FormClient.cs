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

namespace Bai05
{
    public partial class FormClient : Form
    {
        private TcpClient client;
        private NetworkStream ns;
        private bool connected = false;
        private string userName = "";
        public FormClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            userName = txtName.Text.Trim();
            if (userName == "")
            {
                MessageBox.Show("Nhập tên trước!");
                return;
            }

            string ip = txtIP.Text.Trim();
            if (ip == "")
            {
                MessageBox.Show("Nhập IP server trước!");
                return;
            }

            client = new TcpClient();
            try
            {
                await client.ConnectAsync(ip, 8080); // ← IP nhập từ textbox
            }
            catch
            {
                MessageBox.Show("Không thể kết nối tới server!");
                return;
            }

            ns = client.GetStream();
            await SendAsync("login|" + userName);
            connected = true;
            _ = ListenAsync();
        }


        private async Task ListenAsync()
        {
            byte[] buffer = new byte[1024];
            try
            {
                while (client.Connected)
                {
                    int len = await ns.ReadAsync(buffer, 0, buffer.Length);
                    if (len == 0) break;
                    string msg = Encoding.UTF8.GetString(buffer, 0, len);
                    if (msg.StartsWith("food|"))
                    {
                        string food = msg.Substring(5);
                        lblResult.Text = food;
                        rtbClientStatus.AppendText($"Server chọn món: {food}\n");
                    }
                    else
                    {
                        rtbClientStatus.AppendText(msg + "\n");
                    }
                }
            }
            catch
            {
                rtbClientStatus.AppendText("❌ Server đã ngắt kết nối!\n");
            }
        }

        private async Task SendAsync(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            await ns.WriteAsync(data, 0, data.Length);
        }


        private async void btnRandom_Click_1(object sender, EventArgs e)
        {
            if (!connected && ns == null) return;
            string cmd = chkSelfOnly.Checked ? "randomizeself" : "randomize";
            await SendAsync(cmd);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormInput f = new FormInput(userName, ns);
            f.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormView f = new FormView();
            f.ShowDialog();
        }
    }
}

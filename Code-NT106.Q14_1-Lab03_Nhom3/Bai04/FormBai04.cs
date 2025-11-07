using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    public partial class FormBai04 : Form
    {
        // --- Phần biến của Client ---
        private TcpClient client;
        private NetworkStream stream;
        private Task listeningTask;
        private Dictionary<string, Button> seatButtons = new Dictionary<string, Button>();

        // --- Phần biến của Server ---
        private TicketServer serverInstance;

        public FormBai04()
        {
            InitializeComponent();

            foreach (Control control in panelSeats.Controls)
            {
                if (control is Button btn && (btn.Name.StartsWith("btnA") || btn.Name.StartsWith("btnB")))
                {
                    string seatId = btn.Name.Replace("btn", "");
                    seatButtons.Add(seatId, btn);
                    btn.Click += SeatButton_Click;
                }
            }
        }

        //#################################################################
        // PHẦN LOGIC SERVER
        //#################################################################

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                serverInstance = new TicketServer();
                serverInstance.StartServer();
            });

            btnStartServer.Enabled = false;
            btnStartServer.Text = "Server Đang Chạy...";

            Task.Delay(500).ContinueWith(_ =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    ConnectToServer();
                });
            });
        }


        //#################################################################
        // PHẦN LOGIC CLIENT
        //#################################################################

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSeats.Enabled = false;
            btnReset.Enabled = false;
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();

                listeningTask = Task.Run(() => ListenForServerUpdates());

                SendMessage("GET_SEATS");

                panelSeats.Enabled = true;
                btnReset.Enabled = true;
                MessageBox.Show("Đã kết nối Server thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa kết nối được Server: " + ex.Message);

                btnStartServer.Enabled = true;
                btnStartServer.Text = "START SERVER";
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn reset TẤT CẢ vé đã đặt không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SendMessage("RESET_SEATS");
            }
        }

        private void SendMessage(string message)
        {
            if (stream == null || !client.Connected)
            {
                MessageBox.Show("Chưa kết nối server hoặc đã mất kết nối!");
                return;
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi tin: " + ex.Message);
            }
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seatId = btn.Name.Replace("btn", "");
            SendMessage($"BOOK_SEAT:{seatId}");
        }

        private void ListenForServerUpdates()
        {
            byte[] buffer = new byte[2048];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    this.Invoke((MethodInvoker)delegate { ProcessServerMessage(message); });
                }
            }
            catch (Exception)
            {
                if (!this.IsDisposed)
                {
                    this.Invoke((MethodInvoker)delegate { MessageBox.Show("Mất kết nối Server."); });
                }
            }
        }

        private void ProcessServerMessage(string message)
        {
            string[] parts = message.Split(':');
            string command = parts[0];

            if (command == "SEAT_LIST")
            {
                string[] seatData = parts[1].Split(';');
                foreach (string data in seatData)
                {
                    string[] info = data.Split(',');
                    if (info.Length == 2)
                    {
                        UpdateSeatUI(info[0], bool.Parse(info[1]));
                    }
                }
            }
            else if (command == "BOOK_SUCCESS")
            {
                MessageBox.Show($"Bạn đã đặt thành công ghế {parts[1]}!");
                UpdateSeatUI(parts[1], true);
            }
            else if (command == "BOOK_FAIL")
            {
                MessageBox.Show($"Đặt vé {parts[1]} thất bại! Ghế đã có người khác đặt.");
                UpdateSeatUI(parts[1], true);
            }
            else if (command == "SEAT_UPDATED")
            {
                UpdateSeatUI(parts[1], true);
            }
        }

        private void UpdateSeatUI(string seatId, bool isBooked)
        {
            if (seatButtons.ContainsKey(seatId))
            {
                Button btn = seatButtons[seatId];
                if (isBooked)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.Red;
                    btn.Text = "Đã đặt";
                }
                else
                {
                    btn.Enabled = true;
                    btn.BackColor = Color.LimeGreen;
                    btn.Text = seatId;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stream?.Close();
            client?.Close();
        }
    }
}

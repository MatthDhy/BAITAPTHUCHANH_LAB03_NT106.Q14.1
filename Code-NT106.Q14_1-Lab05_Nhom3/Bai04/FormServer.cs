using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bai04
{
    public partial class FormServer : BaseForm
    {
        TcpListener server;
        Thread listenerThread;

        // DANH SÁCH GHẾ ĐÃ ĐẶT (Lưu trong RAM của Server)
        static List<string> bookedSeats = new List<string>();

        public FormServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                int port = int.Parse(txtPort.Text);
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                AddLog($"Server started on Port {port}...");

                listenerThread = new Thread(() => {
                    while (true)
                    {
                        try
                        {
                            TcpClient client = server.AcceptTcpClient();
                            Thread t = new Thread(HandleClient);
                            t.IsBackground = true;
                            t.Start(client);
                        }
                        catch { break; }
                    }
                });
                listenerThread.IsBackground = true;
                listenerThread.Start();

                btnListen.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        // Hàm xử lý từng Client
        void HandleClient(object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string data;

            try
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) return;

                data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                // --- LOGIC XỬ LÝ ---

                // TRƯỜNG HỢP 1: Client xin danh sách ghế đã đặt
                if (data == "GET_BOOKED_SEATS")
                {
                    // Gộp danh sách thành chuỗi: "A1,A2,B5"
                    string response = string.Join(",", bookedSeats);
                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
                }
                // TRƯỜNG HỢP 2: Client gửi đơn đặt vé (Có chữ BOOK ở đầu)
                else if (data.StartsWith("BOOK"))
                {
                    // Cấu trúc gửi lên: "BOOK|A1,A2|Nội dung hóa đơn..."
                    string[] parts = data.Split('|');
                    string seats = parts[1]; // Lấy phần ghế "A1,A2"
                    string billInfo = parts[2]; // Lấy nội dung hóa đơn

                    // Lưu ghế vào bộ nhớ Server
                    if (!string.IsNullOrEmpty(seats))
                    {
                        bookedSeats.AddRange(seats.Split(','));
                    }

                    AddLog(billInfo); // Hiện hóa đơn lên màn hình Server
                }
            }
            catch { }
            finally { client.Close(); }
        }

        void AddLog(string msg)
        {
            if (rtbLog.InvokeRequired) rtbLog.Invoke(new Action<string>(AddLog), msg);
            else { rtbLog.AppendText($"[{DateTime.Now:HH:mm}] {msg}\n"); rtbLog.ScrollToCaret(); }
        }
    }
}
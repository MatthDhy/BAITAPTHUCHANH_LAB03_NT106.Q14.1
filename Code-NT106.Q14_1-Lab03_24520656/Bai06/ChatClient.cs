using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json; // Sử dụng Newtonsoft

namespace Bai06
{
    public class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private bool running = false;

        public string UserName { get; private set; }

        // Events để MainForm lắng nghe
        public event Action<string> OnLog;
        public event Action<ChatMessage> OnMessageReceived;
        public event Action<List<string>> OnUserListReceived;
        public event Action OnDisconnected;

        public bool Connect(string ip, int port, string userName)
        {
            if (running) return false;
            if (string.IsNullOrEmpty(userName))
            {
                OnLog?.Invoke("Username cannot be empty.");
                return false;
            }

            try
            {
                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();
                this.UserName = userName;
                running = true;

                // Bắt đầu luồng nhận dữ liệu
                receiveThread = new Thread(ReceiveLoop);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                // Gửi tin nhắn login
                var loginMsg = new ChatMessage { Type = "login", From = userName };
                Send(loginMsg);

                OnLog?.Invoke("Connected to server.");
                return true;
            }
            catch (Exception ex)
            {
                OnLog?.Invoke($"Failed to connect: {ex.Message}");
                running = false;
                return false;
            }
        }

        public void Disconnect()
        {
            if (!running) return;

            try
            {
                // Gửi tin nhắn disconnect
                var msg = new ChatMessage { Type = "disconnect", From = UserName };
                Send(msg);
            }
            catch { } // Bỏ qua lỗi nếu không gửi được (ví dụ server đã ngắt)

            running = false;
            try { stream?.Close(); } catch { }
            try { client?.Close(); } catch { }
            OnDisconnected?.Invoke();
            OnLog?.Invoke("Disconnected.");
        }

        private void ReceiveLoop()
        {
            try
            {
                while (running)
                {
                    var msg = ReadMessage(stream);
                    if (msg == null) break; // Server ngắt kết nối

                    // Xử lý message nhận được
                    switch (msg.Type)
                    {
                        case "userlist":
                            try
                            {
                                // Dùng Newtonsoft để deserialize
                                var names = JsonConvert.DeserializeObject<List<string>>(msg.Text);
                                OnUserListReceived?.Invoke(names);
                            }
                            catch (Exception ex)
                            {
                                OnLog?.Invoke($"Error processing user list: {ex.Message}");
                            }
                            break;

                        case "message":
                        case "private":
                        case "file":
                            OnMessageReceived?.Invoke(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (running) // Chỉ log lỗi nếu đang chủ động chạy
                {
                    OnLog?.Invoke($"Receive loop error: {ex.Message}");
                }
            }
            finally
            {
                if (running) // Nếu vòng lặp tự vỡ (server sập) mà client chưa chủ động disconnect
                {
                    Disconnect(); // Tự dọn dẹp
                }
            }
        }

        // Gửi tin nhắn công khai
        public void SendMessage(string text)
        {
            var msg = new ChatMessage
            {
                Type = "message",
                From = UserName,
                Text = text
            };
            Send(msg);
        }

        // Gửi tin nhắn riêng
        public void SendPrivate(string to, string text)
        {
            var msg = new ChatMessage
            {
                Type = "private",
                From = UserName,
                To = to,
                Text = text
            };
            Send(msg);
        }

        // Gửi file (công khai hoặc riêng)
        public void SendFile(string to, string filePath)
        {
            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string base64 = Convert.ToBase64String(fileBytes);
                var msg = new ChatMessage
                {
                    Type = "file",
                    From = UserName,
                    To = to, // Sẽ là null nếu gửi public
                    FileName = Path.GetFileName(filePath),
                    FileBase64 = base64
                };
                Send(msg);
            }
            catch (Exception ex)
            {
                OnLog?.Invoke($"Error sending file: {ex.Message}");
            }
        }

        // Hàm gửi chung (Serialize và frame)
        private void Send(ChatMessage m)
        {
            if (!running) return;
            try
            {
                // Dùng Newtonsoft
                string json = JsonConvert.SerializeObject(m);
                byte[] data = Encoding.UTF8.GetBytes(json);
                byte[] len = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data.Length));

                stream.Write(len, 0, 4);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                OnLog?.Invoke($"Send error: {ex.Message}");
                Disconnect(); // Lỗi gửi -> ngắt kết nối
            }
        }

        // Hàm đọc chung (Đọc frame và Deserialize)
        private static ChatMessage ReadMessage(NetworkStream ns)
        {
            var lenbuf = new byte[4];
            int got = 0;
            while (got < 4)
            {
                int r = ns.Read(lenbuf, got, 4 - got);
                if (r == 0) return null; // Ngắt kết nối
                got += r;
            }
            int len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lenbuf, 0));

            var buf = new byte[len];
            int received = 0;
            while (received < len)
            {
                int r = ns.Read(buf, received, len - received);
                if (r == 0) return null; // Ngắt kết nối
                received += r;
            }

            var json = Encoding.UTF8.GetString(buf);
            try
            {
                // Dùng Newtonsoft
                return JsonConvert.DeserializeObject<ChatMessage>(json);
            }
            catch { return null; } // Lỗi parse JSON
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }
        private void StartListen(object sender, EventArgs e)
        {
            // Xử lý lỗi InvalidOperationException
            CheckForIllegalCrossThreadCalls = false;
            

            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.IsBackground = true; // Thread chạy nền
            serverThread.Start();
        }

        // Thread chạy server TCP
        void StartUnsafeThread()
        {
            byte[] recv = new byte[1]; // nhận từng byte

            Socket clientSocket;

            // Tạo socket lắng nghe (IPv4, Stream, TCP)
            Socket listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            //Tái sử dụng lại ip và port
            listenerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);


            // Gán socket lắng nghe đến IP 127.0.0.1 và port 8080
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);

            // Bắt đầu lắng nghe, hàng đợi tối đa 10 kết nối
            listenerSocket.Listen(10);

            // Hiển thị thông báo lên ListView
            listViewCommand.Items.Add(new ListViewItem("Telnet running on 127.0.0.1:8080..."));

            // Đồng ý kết nối
            clientSocket = listenerSocket.Accept();
            listViewCommand.Items.Add(new ListViewItem("New client connected."));

            try
            {
                while (true)
                {
                    string text = "";
                    int bytesReceived = 0;
                    do
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0)
                        {
                            // Client đã đóng kết nối
                            listViewCommand.Items.Add(new ListViewItem("Client disconnected."));
                            clientSocket.Close();
                            listenerSocket.Close();
                            return;
                        }

                        text += Encoding.ASCII.GetString(recv, 0, bytesReceived);

                    } while (text.Length == 0 || text[text.Length - 1] != '\n');

                    // Hiển thị dữ liệu nhận được
                    listViewCommand.Items.Add(new ListViewItem(text.Trim()));
                }
            }
            catch (SocketException)
            {
                listViewCommand.Items.Add(new ListViewItem("Client disconnected."));
            }
            finally
            {
                clientSocket.Close();
                listenerSocket.Close();
            }

        }

    }
}

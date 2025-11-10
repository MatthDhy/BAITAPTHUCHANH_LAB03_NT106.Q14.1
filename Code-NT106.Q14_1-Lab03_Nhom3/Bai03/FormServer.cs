using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bai03
{
    public partial class FormServer : Form
    {
        TcpListener listener;
        TcpClient client;
        NetworkStream stream;
        public FormServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(StartServer);
            serverThread.Start();
        }
        void StartServer()
        {
            int port = int.Parse(txtPort.Text);
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            listBoxMessage.Items.Add($"Server đang lắng nghe tại cổng {port}...");

            client = listener.AcceptTcpClient();
            listBoxMessage.Items.Add("✅ Client đã kết nối!");

            stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytes;

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string msg;
                while ((msg = reader.ReadLine()) != null)
                {
                    listBoxMessage.Items.Add("Client: " + msg);
                }
            }
        }

    }
}

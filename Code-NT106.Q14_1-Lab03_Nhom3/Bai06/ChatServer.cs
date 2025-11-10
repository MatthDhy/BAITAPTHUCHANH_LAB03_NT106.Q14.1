using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Bai06
{
    public class ChatServer
    {
        private TcpListener listener;
        private Thread listenThread;
        private readonly List<ClientHandler> clients = new List<ClientHandler>();
        private readonly int port;
        private bool running = false;

        public event Action<string> OnLog;
        public event Action<List<string>> OnUserListChanged;

        public ChatServer(int port)
        {
            this.port = port;
        }

        public void Start()
        {
            if (running) return;
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            running = true;
            listenThread = new Thread(ListenLoop) { IsBackground = true };
            listenThread.Start();
            Log($"Server started on port {port}");
        }

        public void Stop()
        {
            running = false;
            try { listener?.Stop(); } catch { }
            lock (clients)
            {
                foreach (var c in clients.ToArray()) c.Disconnect();
                clients.Clear();
            }
            Log("Server stopped");
            RaiseUserListChanged();
        }

        private void ListenLoop()
        {
            while (running)
            {
                try
                {
                    var tcp = listener.AcceptTcpClient();
                    var handler = new ClientHandler(tcp, this);
                    lock (clients) { clients.Add(handler); }
                    handler.Start();
                    Log("Client connected");
                }
                catch { break; }
            }
        }

        internal void Broadcast(ChatMessage msg, ClientHandler exclude = null)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(msg);
            var data = Encoding.UTF8.GetBytes(json);
            var framed = PrependLength(data);
            lock (clients)
            {
                foreach (var c in clients.ToArray())
                {
                    if (c == exclude) continue;
                    try { c.SendRaw(framed); } catch { }
                }
            }
        }

        internal void RemoveClient(ClientHandler client)
        {
            lock (clients) { clients.Remove(client); }
            RaiseUserListChanged();
            Log($"Client {client.UserName} disconnected");
        }

        internal void RaiseUserListChanged()
        {
            var names = new List<string>();
            lock (clients)
            {
                foreach (var c in clients)
                    if (!string.IsNullOrEmpty(c.UserName)) names.Add(c.UserName);
            }

            OnUserListChanged?.Invoke(names);

            var msg = new ChatMessage { Type = "userlist", Text = Newtonsoft.Json.JsonConvert.SerializeObject(names) };
            Broadcast(msg);
        }

        internal void Log(string text) => OnLog?.Invoke(text);

        private static byte[] PrependLength(byte[] data)
        {
            var len = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(data.Length));
            var framed = new byte[len.Length + data.Length];
            Buffer.BlockCopy(len, 0, framed, 0, len.Length);
            Buffer.BlockCopy(data, 0, framed, len.Length, data.Length);
            return framed;
        }
    }

    internal class ClientHandler
    {
        private readonly TcpClient tcp;
        private readonly ChatServer server;
        private NetworkStream ns;
        private Thread recvThread;
        public string UserName { get; private set; }
        private bool running = false;

        public ClientHandler(TcpClient tcp, ChatServer server)
        {
            this.tcp = tcp;
            this.server = server;
        }

        public void Start()
        {
            ns = tcp.GetStream();
            running = true;
            recvThread = new Thread(ReceiveLoop) { IsBackground = true };
            recvThread.Start();
        }

        public void Disconnect()
        {
            running = false;
            try { tcp.Close(); } catch { }
        }

        public void SendRaw(byte[] framed)
        {
            try
            {
                ns.Write(framed, 0, framed.Length);
                ns.Flush();
            }
            catch
            {
                Disconnect();
                server.RemoveClient(this);
            }
        }

        private void ReceiveLoop()
        {
            try
            {
                while (running && tcp.Connected)
                {
                    var msg = ReadMessage(ns);
                    if (msg == null) break;
                    Handle(msg);
                }
            }
            catch { }
            finally
            {
                running = false;
                server.RemoveClient(this);
            }
        }

        private static ChatMessage ReadMessage(NetworkStream ns)
        {
            var lenbuf = new byte[4];
            int got = 0;
            while (got < 4)
            {
                int r = ns.Read(lenbuf, got, 4 - got);
                if (r == 0) return null;
                got += r;
            }
            int len = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(lenbuf, 0));
            var buf = new byte[len];
            int received = 0;
            while (received < len)
            {
                int r = ns.Read(buf, received, len - received);
                if (r == 0) return null;
                received += r;
            }
            var json = Encoding.UTF8.GetString(buf);
            try { return Newtonsoft.Json.JsonConvert.DeserializeObject<ChatMessage>(json); }
            catch { return null; }
        }

        private void Handle(ChatMessage m)
        {
            switch (m.Type)
            {
                case "login":
                    UserName = m.From;
                    server.Log($"User logged in: {UserName}");
                    server.RaiseUserListChanged();
                    break;

                case "message":
                    server.Log($"{m.From}: {m.Text}");
                    server.Broadcast(m);
                    break;

                case "private":
                    server.Log($"Private {m.From} -> {m.To}: {m.Text}");
                    server.Broadcast(m);
                    break;

                case "file":
                    server.Log($"File from {m.From}: {m.FileName}");
                    server.Broadcast(m);
                    break;

                case "disconnect":
                    Disconnect();
                    break;
            }
        }
    }
}

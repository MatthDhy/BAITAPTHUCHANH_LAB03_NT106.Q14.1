using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai05.Models;

namespace Bai05
{
    public partial class FormServer : Form
    {
        private TcpListener listener;
        private bool running = false;
        private Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
        private readonly string connStr = "Data Source=Database/monan.db";
        public FormServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            InitDatabase();
        }

        private void InitDatabase()
        {
            string folder = "Database";
            string dbPath = Path.Combine(folder, "monan.db");


            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);


            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection("Data Source=" + dbPath))
                {
                    conn.Open();
                    string sql = "CREATE TABLE Food(Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, ImagePath TEXT, Author TEXT)";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            string clientName = "";

            while (client.Connected)
            {
                int bytesRead;
                try
                {
                    bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                }
                catch { break; }

                string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                string[] parts = msg.Split('|');
                string command = parts[0];


                try
                {
                    switch (command)
                    {
                        case "login":
                            clientName = parts[1];
                            if (clients.ContainsKey(clientName))
                            {
                                await SendAsync(ns, "Somebody already used this name!");
                                rtbStatus.AppendText($"{clientName} tried to login but name was taken.\n"); // Thêm log
                                client.Close();
                            }
                            else
                            {
                                clients.Add(clientName, client);
                                lstClients.Items.Add(clientName);
                                rtbStatus.AppendText($"{clientName} connected.\n");
                                await SendAsync(ns, "hello");
                            }
                            break;

                        case "randomize":
                            string food = RandomizeFood();
                            await SendAsync(ns, "food|" + food);
                            rtbStatus.AppendText($"{clientName} requested random food.\n");
                            break;

                        case "addfood":
                            string foodName = parts[1];
                            string imgPath = parts[2];

                            AddFood(foodName, imgPath, clientName);

                            rtbStatus.AppendText($"{clientName} added {foodName}.\n");
                            await SendAsync(ns, "added|" + foodName);
                            break;

                        case "randomizeself":
                            string own = RandomizeFood(clientName);
                            await SendAsync(ns, "food|" + own);
                            rtbStatus.AppendText($"{clientName} requested random 'self' food.\n");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    rtbStatus.AppendText($"[ERROR] from {clientName}: {ex.Message}\n");

                    await SendAsync(ns, $"[ERROR] Server failed to process command: {ex.Message}");
                }
            }

            if (clientName != "" && clients.ContainsKey(clientName))
            {
                clients.Remove(clientName);
                lstClients.Items.Remove(clientName);
                rtbStatus.AppendText($"{clientName} disconnected.\n");
            }
        }

        private async void btnOpenServer_Click(object sender, EventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            running = true;
            rtbStatus.AppendText($"Server started on port {port}\n");

            await Task.Run(async () =>
            {
                while (running)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(client);
                }
            });
        }

        private async Task SendAsync(NetworkStream ns, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            await ns.WriteAsync(data, 0, data.Length);
        }

        private string RandomizeFood(string author = "")
        {
            List<string> foods = new List<string>();
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = author == "" ?
                    "SELECT Name FROM Food" :
                    "SELECT Name FROM Food WHERE Author=@a";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (author != "")
                        cmd.Parameters.AddWithValue("@a", author);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foods.Add(reader.GetString(0));
                        }
                    }
                }
            }

            if (foods.Count == 0) return "Không có món ăn nào!";
            Random r = new Random();
            return foods[r.Next(foods.Count)];
        }

        private void AddFood(string name, string img, string author)
        {
            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();
                string sql = "INSERT INTO Food(Name, ImagePath, Author) VALUES(@n,@i,@a)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@i", img);
                    cmd.Parameters.AddWithValue("@a", author);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            running = false;
            listener.Stop();
            foreach (var c in clients.Values)
                c.Close();
            clients.Clear();
            lstClients.Items.Clear();
            rtbStatus.AppendText("Server stopped.\n");
        }
    }
}

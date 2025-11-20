using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Bai06
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private ChatServer server;
        private ChatClient client;
        private int port = 8080;


        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            int.TryParse(txtPort.Text, out port);
            if (rbServer.Checked)
            {
                if (server == null)
                {
                    server = new ChatServer(port);
                    server.OnLog += Server_OnLog;
                    server.OnUserListChanged += Server_OnUserListChanged;
                    server.Start();
                    lblStatus.Text = $"Status: Server listening on port {port}";
                    btnStartStop.Text = "Stop Server";
                }
                else
                {
                    server.Stop(); server = null;
                    lblStatus.Text = "Status: Idle";
                    btnStartStop.Text = "Start Server / Connect";
                    lstUsers.Items.Clear();
                }
            }
            else // client
            {
                if (client == null)
                {
                    client = new ChatClient();
                    client.OnLog += Client_OnLog;
                    client.OnMessageReceived += Client_OnMessageReceived;
                    client.OnUserListReceived += Client_OnUserListReceived;
                    try
                    {
                        client.Connect(txtServerIP.Text.Trim(), port, txtName.Text.Trim());
                        lblStatus.Text = $"Status: Connected to {txtServerIP.Text}:{port} as {txtName.Text}";
                        btnStartStop.Text = "Disconnect";
                    }
                    catch (Exception ex)
                    {
                        AppendLog("Connect error: " + ex.Message);
                        client = null;
                    }
                }
                else
                {
                    client.Disconnect(); client = null;
                    lblStatus.Text = "Status: Idle";
                    btnStartStop.Text = "Start Server / Connect";
                    lstUsers.Items.Clear();
                }
            }
        }

        private void Server_OnUserListChanged(List<string> users)
        {
            this.BeginInvoke((Action)(() =>
            {
                lstUsers.Items.Clear();
                foreach (var n in users) lstUsers.Items.Add(n);
            }));
        }

        private void Server_OnLog(string msg)
        {
            AppendLog("[Server] " + msg);
        }

        private void Client_OnUserListReceived(List<string> users)
        {
            this.BeginInvoke((Action)(() =>
            {
                lstUsers.Items.Clear();
                foreach (var n in users) lstUsers.Items.Add(n);
            }));
        }

        private void Client_OnMessageReceived(ChatMessage m)
        {
            this.BeginInvoke((Action)(() =>
            {
                if (m.Type == "message") AppendLog($"{m.From}: {m.Text}");
                else if (m.Type == "private")
                {
                    if (m.To == client?.UserName || m.From == client?.UserName)
                        AppendLog($"[Private] {m.From} -> {m.To}: {m.Text}");
                }
                else if (m.Type == "file")
                {
                    if (string.IsNullOrEmpty(m.To) || m.To == client?.UserName || m.From == client?.UserName)
                    {
                        AppendLog($"[File] {m.From} sent {m.FileName}");
                        var save = MessageBox.Show($"Receive file {m.FileName} from {m.From}. Save?", "File received", MessageBoxButtons.YesNo);
                        if (save == DialogResult.Yes)
                        {
                            var buf = Convert.FromBase64String(m.FileBase64);
                            var folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                            var path = Path.Combine(folder, m.FileName);
                            File.WriteAllBytes(path, buf);
                            MessageBox.Show($"Saved to {path}");
                        }
                    }
                }
            }));
        }

        private void Client_OnLog(string msg)
        {
            AppendLog("[Client] " + msg);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (client == null) { MessageBox.Show("Not connected."); return; }
            var text = txtMessage.Text.Trim(); if (string.IsNullOrEmpty(text)) return;
            string to = lstUsers.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(to) && to != client.UserName)
            {
                client.SendPrivate(to, text);
                AppendLog($"[To {to}] {client.UserName}: {text}");
            }
            else
            {
                client.SendMessage(text);
            }
            txtMessage.Clear();
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (client == null) { MessageBox.Show("Not connected."); return; }
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images/Text|*.jpg;*.jpeg;*.png;*.txt|All files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string to = lstUsers.SelectedItem?.ToString();
                    client.SendFile(to, dlg.FileName);
                    AppendLog($"[File sent] {Path.GetFileName(dlg.FileName)} to {(to ?? "ALL")}");
                }
            }
        }

        private void AppendLog(string text)
        {
            if (txtLog.InvokeRequired)
                txtLog.BeginInvoke((Action)(() => txtLog.AppendText(text + "\r\n")));
            else
                txtLog.AppendText(text + "\r\n");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { server?.Stop(); } catch { }
            try { client?.Disconnect(); } catch { }
        }
    }
}

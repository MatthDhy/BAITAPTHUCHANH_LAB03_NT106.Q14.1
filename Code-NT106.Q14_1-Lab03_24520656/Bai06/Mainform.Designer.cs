namespace Bai06
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.grpMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.rbClient);
            this.grpMode.Controls.Add(this.rbServer);
            this.grpMode.Location = new System.Drawing.Point(12, 12);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(160, 60);
            this.grpMode.TabIndex = 0;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "Mode";
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Location = new System.Drawing.Point(83, 25);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(51, 19);
            this.rbClient.TabIndex = 1;
            this.rbClient.Text = "Client";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Checked = true;
            this.rbServer.Location = new System.Drawing.Point(15, 25);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(56, 19);
            this.rbServer.TabIndex = 0;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "Server";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(190, 19);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(31, 15);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(227, 16);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(60, 23);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "8080";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(190, 45);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(56, 15);
            this.lblIP.TabIndex = 3;
            this.lblIP.Text = "Server IP:";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(252, 42);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(150, 23);
            this.txtServerIP.TabIndex = 4;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(430, 16);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(180, 49);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.Text = "Start Server / Connect";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(620, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(667, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 23);
            this.txtName.TabIndex = 7;
            this.txtName.Text = "User1234";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(500, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: Idle";
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 15;
            this.lstUsers.Location = new System.Drawing.Point(12, 110);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(150, 379);
            this.lstUsers.TabIndex = 9;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(168, 110);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(619, 379);
            this.txtLog.TabIndex = 10;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 505);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(620, 23);
            this.txtMessage.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(640, 505);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 23);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(716, 505);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(70, 23);
            this.btnSendFile.TabIndex = 13;
            this.btnSendFile.Text = "Send File";
            this.btnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.grpMode);
            this.Name = "MainForm";
            this.Text = "ChatRoom TCP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSendFile;
    }
}

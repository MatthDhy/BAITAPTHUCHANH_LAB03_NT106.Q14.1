namespace Bai06
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUserInfo;
        private System.Windows.Forms.TabPage tabApiDocs;

        private System.Windows.Forms.PictureBox picAvatar;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMail;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.TextBox txtEmail;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.RichTextBox rtbLog;

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUserInfo = new System.Windows.Forms.TabPage();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.tabApiDocs = new System.Windows.Forms.TabPage();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tabControl.SuspendLayout();
            this.tabUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.tabApiDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUserInfo);
            this.tabControl.Controls.Add(this.tabApiDocs);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(600, 500);
            this.tabControl.TabIndex = 0;
            // 
            // tabUserInfo
            // 
            this.tabUserInfo.Controls.Add(this.picAvatar);
            this.tabUserInfo.Controls.Add(this.lblId);
            this.tabUserInfo.Controls.Add(this.txtId);
            this.tabUserInfo.Controls.Add(this.lblUser);
            this.tabUserInfo.Controls.Add(this.txtUsername);
            this.tabUserInfo.Controls.Add(this.lblName);
            this.tabUserInfo.Controls.Add(this.txtFullname);
            this.tabUserInfo.Controls.Add(this.lblMail);
            this.tabUserInfo.Controls.Add(this.txtEmail);
            this.tabUserInfo.Controls.Add(this.btnRefresh);
            this.tabUserInfo.Controls.Add(this.rtbLog);
            this.tabUserInfo.Location = new System.Drawing.Point(4, 25);
            this.tabUserInfo.Name = "tabUserInfo";
            this.tabUserInfo.Size = new System.Drawing.Size(592, 471);
            this.tabUserInfo.TabIndex = 0;
            this.tabUserInfo.Text = "User Info";
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(400, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(20, 20);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(100, 23);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(120, 15);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(240, 22);
            this.txtId.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(20, 60);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 23);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(120, 55);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(240, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(20, 100);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Full Name:";
            // 
            // txtFullname
            // 
            this.txtFullname.Location = new System.Drawing.Point(120, 95);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.ReadOnly = true;
            this.txtFullname.Size = new System.Drawing.Size(240, 22);
            this.txtFullname.TabIndex = 6;
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(20, 140);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(100, 23);
            this.lblMail.TabIndex = 7;
            this.lblMail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 135);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(240, 22);
            this.txtEmail.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(280, 170);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(20, 210);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(530, 220);
            this.rtbLog.TabIndex = 10;
            this.rtbLog.Text = "";
            // 
            // tabApiDocs
            // 
            this.tabApiDocs.Controls.Add(this.webView);
            this.tabApiDocs.Location = new System.Drawing.Point(4, 25);
            this.tabApiDocs.Name = "tabApiDocs";
            this.tabApiDocs.Size = new System.Drawing.Size(592, 471);
            this.tabApiDocs.TabIndex = 1;
            this.tabApiDocs.Text = "API Docs";
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(592, 471);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // UserForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 520);
            this.Controls.Add(this.tabControl);
            this.Name = "UserForm";
            this.Text = "User Information";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabUserInfo.ResumeLayout(false);
            this.tabUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.tabApiDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

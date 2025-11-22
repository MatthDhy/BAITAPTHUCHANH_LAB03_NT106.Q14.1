namespace Bai06
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "LOGIN TO SYSTEM";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(60, 20);

            // lblUser
            this.lblUser.Text = "Username:";
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(20, 80);

            // txtUser
            this.txtUser.Location = new System.Drawing.Point(120, 75);
            this.txtUser.Size = new System.Drawing.Size(180, 22);

            // lblPass
            this.lblPass.Text = "Password:";
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(20, 120);

            // txtPass
            this.txtPass.Location = new System.Drawing.Point(120, 115);
            this.txtPass.Size = new System.Drawing.Size(180, 22);
            this.txtPass.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Location = new System.Drawing.Point(120, 160);
            this.btnLogin.Size = new System.Drawing.Size(120, 35);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // LoginForm
            this.ClientSize = new System.Drawing.Size(350, 230);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Login";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

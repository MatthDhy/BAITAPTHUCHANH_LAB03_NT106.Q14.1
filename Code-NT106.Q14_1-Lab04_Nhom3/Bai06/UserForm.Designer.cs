namespace Bai06
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.TextBox txtEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblId = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();

            this.txtId = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();

            this.SuspendLayout();

            // lblId
            this.lblId.Text = "ID:";
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(30, 30);

            // txtId
            this.txtId.Location = new System.Drawing.Point(120, 27);
            this.txtId.Width = 220;
            this.txtId.ReadOnly = true;

            // lblUser
            this.lblUser.Text = "Username:";
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(30, 70);

            // txtUsername
            this.txtUsername.Location = new System.Drawing.Point(120, 67);
            this.txtUsername.Width = 220;
            this.txtUsername.ReadOnly = true;

            // lblName
            this.lblName.Text = "Full Name:";
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 110);

            // txtFullname
            this.txtFullname.Location = new System.Drawing.Point(120, 107);
            this.txtFullname.Width = 220;
            this.txtFullname.ReadOnly = true;

            // lblMail
            this.lblMail.Text = "Email:";
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(30, 150);

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 147);
            this.txtEmail.Width = 220;
            this.txtEmail.ReadOnly = true;

            // UserForm
            this.ClientSize = new System.Drawing.Size(380, 210);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtEmail);

            this.Text = "User Information";
            this.Load += new System.EventHandler(this.UserForm_Load);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

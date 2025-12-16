namespace Bai06.Forms
{
    partial class ComposeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.ListBox listAttachments;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Button btnSend;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTo = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.listAttachments = new System.Windows.Forms.ListBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.ClientSize = new System.Drawing.Size(600, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compose Email";

            // To Label
            this.lblTo.Text = "To";
            this.lblTo.Location = new System.Drawing.Point(20, 15);

            // To TextBox
            this.txtTo.Location = new System.Drawing.Point(20, 35);
            this.txtTo.Size = new System.Drawing.Size(560, 25);

            // Subject Label
            this.lblSubject.Text = "Subject";
            this.lblSubject.Location = new System.Drawing.Point(20, 65);

            // Subject TextBox
            this.txtSubject.Location = new System.Drawing.Point(20, 85);
            this.txtSubject.Size = new System.Drawing.Size(560, 25);

            // Body
            this.txtBody.Location = new System.Drawing.Point(20, 120);
            this.txtBody.Size = new System.Drawing.Size(560, 270);

            // Attachments
            this.listAttachments.Location = new System.Drawing.Point(20, 400);
            this.listAttachments.Size = new System.Drawing.Size(360, 90);

            // Attach Button
            this.btnAttach.Text = "Attach";
            this.btnAttach.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnAttach.ForeColor = System.Drawing.Color.White;
            this.btnAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttach.FlatAppearance.BorderSize = 0;
            this.btnAttach.Location = new System.Drawing.Point(400, 400);
            this.btnAttach.Size = new System.Drawing.Size(180, 35);
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);

            // Send Button
            this.btnSend.Text = "Send";
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Location = new System.Drawing.Point(400, 445);
            this.btnSend.Size = new System.Drawing.Size(180, 35);
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // Add
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.listAttachments);
            this.Controls.Add(this.btnAttach);
            this.Controls.Add(this.btnSend);

            this.ResumeLayout(false);
        }
    }
}

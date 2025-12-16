namespace Bai06.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView listViewInbox;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnReply;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listViewInbox = new System.Windows.Forms.ListView();
            this.colFrom = new System.Windows.Forms.ColumnHeader();
            this.colSubject = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnReply = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inbox";

            // Inbox ListView
            this.listViewInbox.Location = new System.Drawing.Point(20, 60);
            this.listViewInbox.Size = new System.Drawing.Size(360, 430);
            this.listViewInbox.View = System.Windows.Forms.View.Details;
            this.listViewInbox.FullRowSelect = true;
            this.listViewInbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colFrom, this.colSubject, this.colDate
            });
            this.listViewInbox.SelectedIndexChanged += new System.EventHandler(this.listViewInbox_SelectedIndexChanged);

            this.colFrom.Text = "From";
            this.colFrom.Width = 120;
            this.colSubject.Text = "Subject";
            this.colSubject.Width = 140;
            this.colDate.Text = "Date";
            this.colDate.Width = 100;

            // Buttons
            this.btnNew.Text = "New";
            this.btnReply.Text = "Reply";
            this.btnNew.BackColor = this.btnReply.BackColor =
                System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnNew.ForeColor = this.btnReply.ForeColor =
                System.Drawing.Color.White;
            this.btnNew.FlatStyle = this.btnReply.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnNew.Location = new System.Drawing.Point(20, 15);
            this.btnReply.Location = new System.Drawing.Point(110, 15);
            this.btnNew.Size = this.btnReply.Size = new System.Drawing.Size(80, 30);

            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);

            // Detail
            this.txtFrom.Location = new System.Drawing.Point(400, 60);
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(480, 25);

            this.txtSubject.Location = new System.Drawing.Point(400, 95);
            this.txtSubject.ReadOnly = true;
            this.txtSubject.Size = new System.Drawing.Size(480, 25);

            this.txtBody.Location = new System.Drawing.Point(400, 130);
            this.txtBody.Size = new System.Drawing.Size(480, 360);
            this.txtBody.ReadOnly = true;

            // Add
            this.Controls.Add(this.listViewInbox);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtBody);

            this.ResumeLayout(false);
        }
    }
}

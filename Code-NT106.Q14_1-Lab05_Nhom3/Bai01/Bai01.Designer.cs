namespace Bai01
{
    partial class Bai01
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtReceiveName = new System.Windows.Forms.TextBox();
            this.lblReceiveName = new System.Windows.Forms.Label();
            this.txtSendName = new System.Windows.Forms.TextBox();
            this.lblSendName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(43, 38);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(48, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From";
            // 
            // txtSubject
            // 
            this.txtSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubject.Location = new System.Drawing.Point(120, 161);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(547, 27);
            this.txtSubject.TabIndex = 1;
            // 
            // txtTo
            // 
            this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(137, 89);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(289, 27);
            this.txtTo.TabIndex = 2;
            // 
            // txtFrom
            // 
            this.txtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(137, 38);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(289, 27);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.Text = "24521358@gm.uit.edu.vn";
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBody.Location = new System.Drawing.Point(120, 216);
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(547, 206);
            this.txtBody.TabIndex = 4;
            this.txtBody.Text = "";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubject.Location = new System.Drawing.Point(30, 161);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(65, 20);
            this.lblSubject.TabIndex = 5;
            this.lblSubject.Text = "Subject";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(43, 89);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(28, 20);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBody.Location = new System.Drawing.Point(30, 216);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(47, 20);
            this.lblBody.TabIndex = 7;
            this.lblBody.Text = "Body";
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.MistyRose;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(715, 402);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 40);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtReceiveName
            // 
            this.txtReceiveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveName.Location = new System.Drawing.Point(610, 89);
            this.txtReceiveName.Name = "txtReceiveName";
            this.txtReceiveName.Size = new System.Drawing.Size(136, 27);
            this.txtReceiveName.TabIndex = 10;
            // 
            // lblReceiveName
            // 
            this.lblReceiveName.AutoSize = true;
            this.lblReceiveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveName.Location = new System.Drawing.Point(517, 93);
            this.lblReceiveName.Name = "lblReceiveName";
            this.lblReceiveName.Size = new System.Drawing.Size(75, 20);
            this.lblReceiveName.TabIndex = 9;
            this.lblReceiveName.Text = "Receiver";
            // 
            // txtSendName
            // 
            this.txtSendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendName.Location = new System.Drawing.Point(610, 35);
            this.txtSendName.Name = "txtSendName";
            this.txtSendName.Size = new System.Drawing.Size(136, 27);
            this.txtSendName.TabIndex = 12;
            // 
            // lblSendName
            // 
            this.lblSendName.AutoSize = true;
            this.lblSendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendName.Location = new System.Drawing.Point(530, 42);
            this.lblSendName.Name = "lblSendName";
            this.lblSendName.Size = new System.Drawing.Size(62, 20);
            this.lblSendName.TabIndex = 11;
            this.lblSendName.Text = "Sender";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.MistyRose;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(715, 332);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 40);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Bai01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(856, 478);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtSendName);
            this.Controls.Add(this.lblSendName);
            this.Controls.Add(this.txtReceiveName);
            this.Controls.Add(this.lblReceiveName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblFrom);
            this.Name = "Bai01";
            this.Text = "Bai01";
            this.Load += new System.EventHandler(this.Bai01_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.RichTextBox txtBody;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtReceiveName;
        private System.Windows.Forms.Label lblReceiveName;
        private System.Windows.Forms.TextBox txtSendName;
        private System.Windows.Forms.Label lblSendName;
        private System.Windows.Forms.Button btnDelete;
    }
}
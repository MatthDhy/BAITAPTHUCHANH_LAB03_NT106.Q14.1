namespace Bai03
{
    partial class Bai03
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
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDownFile = new System.Windows.Forms.Button();
            this.btnDownSource = new System.Windows.Forms.Button();
            this.btnViewSource = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(15, 147);
            this.webView.Margin = new System.Windows.Forms.Padding(4);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(1040, 483);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(45, 20);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(589, 41);
            this.txtAddress.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(669, 20);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(146, 40);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.LightPink;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(850, 20);
            this.btnReload.Margin = new System.Windows.Forms.Padding(4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(146, 40);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDownFile
            // 
            this.btnDownFile.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDownFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownFile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownFile.Location = new System.Drawing.Point(422, 79);
            this.btnDownFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownFile.Name = "btnDownFile";
            this.btnDownFile.Size = new System.Drawing.Size(146, 40);
            this.btnDownFile.TabIndex = 4;
            this.btnDownFile.Text = "Down File";
            this.btnDownFile.UseVisualStyleBackColor = false;
            this.btnDownFile.Click += new System.EventHandler(this.btnDownFile_Click);
            // 
            // btnDownSource
            // 
            this.btnDownSource.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnDownSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownSource.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownSource.Location = new System.Drawing.Point(626, 79);
            this.btnDownSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownSource.Name = "btnDownSource";
            this.btnDownSource.Size = new System.Drawing.Size(171, 40);
            this.btnDownSource.TabIndex = 5;
            this.btnDownSource.Text = "Down Resource";
            this.btnDownSource.UseVisualStyleBackColor = false;
            this.btnDownSource.Click += new System.EventHandler(this.btnDownSource_Click);
            // 
            // btnViewSource
            // 
            this.btnViewSource.BackColor = System.Drawing.Color.Azure;
            this.btnViewSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSource.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSource.Location = new System.Drawing.Point(194, 79);
            this.btnViewSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewSource.Name = "btnViewSource";
            this.btnViewSource.Size = new System.Drawing.Size(152, 40);
            this.btnViewSource.TabIndex = 6;
            this.btnViewSource.Text = "View Sources";
            this.btnViewSource.UseVisualStyleBackColor = false;
            this.btnViewSource.Click += new System.EventHandler(this.btnViewSource_Click);
            // 
            // Bai03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 647);
            this.Controls.Add(this.btnViewSource);
            this.Controls.Add(this.btnDownSource);
            this.Controls.Add(this.btnDownFile);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.webView);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Bai03";
            this.Text = "Bai03";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDownFile;
        private System.Windows.Forms.Button btnDownSource;
        private System.Windows.Forms.Button btnViewSource;
    }
}


using System.Drawing;
using System.Windows.Forms;

namespace Bai04
{
    partial class FormClient
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
            this.lblBigTitle = new System.Windows.Forms.Label();
            this.pnlConnection = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.pnlBooking = new System.Windows.Forms.Panel();
            this.btnBook = new System.Windows.Forms.Button();
            this.cbMovie = new System.Windows.Forms.ComboBox();
            this.lblMovie = new System.Windows.Forms.Label();
            this.txtSeatCount = new System.Windows.Forms.NumericUpDown();
            this.lblSeatCount = new System.Windows.Forms.Label();
            this.cbCinema = new System.Windows.Forms.ComboBox();
            this.lblCinema = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlMovies = new System.Windows.Forms.Panel();
            this.lblMoviesTitle = new System.Windows.Forms.Label();
            this.flpMovieList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pnlConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeatCount)).BeginInit();
            this.pnlMovies.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBigTitle
            // 
            this.lblBigTitle.AutoSize = true;
            this.lblBigTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBigTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBigTitle.ForeColor = System.Drawing.Color.White;
            this.lblBigTitle.Location = new System.Drawing.Point(116, 146);
            this.lblBigTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBigTitle.Name = "lblBigTitle";
            this.lblBigTitle.Size = new System.Drawing.Size(263, 207);
            this.lblBigTitle.TabIndex = 0;
            this.lblBigTitle.Text = "THÔNG\r\nTIN ĐẶT\r\nVÉ";
            this.lblBigTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlConnection
            // 
            this.pnlConnection.BackColor = System.Drawing.Color.Transparent;
            this.pnlConnection.Controls.Add(this.pictureBox1);
            this.pnlConnection.Controls.Add(this.btnConnect);
            this.pnlConnection.Controls.Add(this.txtServerIP);
            this.pnlConnection.Controls.Add(this.lblIP);
            this.pnlConnection.Controls.Add(this.txtPort);
            this.pnlConnection.Controls.Add(this.lblPort);
            this.pnlConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConnection.Location = new System.Drawing.Point(0, 0);
            this.pnlConnection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlConnection.Name = "pnlConnection";
            this.pnlConnection.Size = new System.Drawing.Size(1260, 99);
            this.pnlConnection.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bai04.Properties.Resources.Gemini_Generated_Image_v0h1rzv0h1rzv0h1_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Location = new System.Drawing.Point(1034, 24);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(140, 49);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtServerIP
            // 
            this.txtServerIP.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtServerIP.Location = new System.Drawing.Point(809, 37);
            this.txtServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(199, 29);
            this.txtServerIP.TabIndex = 3;
            this.txtServerIP.Text = "127.0.0.1";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.Location = new System.Drawing.Point(689, 38);
            this.lblIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(96, 23);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "SERVER IP:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtPort.Location = new System.Drawing.Point(556, 37);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(105, 29);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8080";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPort.ForeColor = System.Drawing.Color.White;
            this.lblPort.Location = new System.Drawing.Point(476, 38);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(59, 23);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "PORT:";
            // 
            // pnlBooking
            // 
            this.pnlBooking.BackColor = System.Drawing.Color.Transparent;
            this.pnlBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBooking.Controls.Add(this.btnBook);
            this.pnlBooking.Controls.Add(this.cbMovie);
            this.pnlBooking.Controls.Add(this.lblMovie);
            this.pnlBooking.Controls.Add(this.txtSeatCount);
            this.pnlBooking.Controls.Add(this.lblSeatCount);
            this.pnlBooking.Controls.Add(this.cbCinema);
            this.pnlBooking.Controls.Add(this.lblCinema);
            this.pnlBooking.Controls.Add(this.txtPhone);
            this.pnlBooking.Controls.Add(this.lblPhone);
            this.pnlBooking.Controls.Add(this.txtName);
            this.pnlBooking.Controls.Add(this.lblName);
            this.pnlBooking.Location = new System.Drawing.Point(333, 98);
            this.pnlBooking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBooking.Name = "pnlBooking";
            this.pnlBooking.Size = new System.Drawing.Size(822, 299);
            this.pnlBooking.TabIndex = 2;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBook.Enabled = false;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(303, 214);
            this.btnBook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(200, 50);
            this.btnBook.TabIndex = 10;
            this.btnBook.Text = "ĐẶT VÉ";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // cbMovie
            // 
            this.cbMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbMovie.FormattingEnabled = true;
            this.cbMovie.Location = new System.Drawing.Point(513, 139);
            this.cbMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMovie.Name = "cbMovie";
            this.cbMovie.Size = new System.Drawing.Size(274, 31);
            this.cbMovie.TabIndex = 9;
            // 
            // lblMovie
            // 
            this.lblMovie.AutoSize = true;
            this.lblMovie.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMovie.ForeColor = System.Drawing.Color.White;
            this.lblMovie.Location = new System.Drawing.Point(393, 141);
            this.lblMovie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMovie.Name = "lblMovie";
            this.lblMovie.Size = new System.Drawing.Size(110, 23);
            this.lblMovie.TabIndex = 8;
            this.lblMovie.Text = "CHỌN PHIM:";
            // 
            // txtSeatCount
            // 
            this.txtSeatCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSeatCount.Location = new System.Drawing.Point(657, 98);
            this.txtSeatCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeatCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtSeatCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSeatCount.Name = "txtSeatCount";
            this.txtSeatCount.Size = new System.Drawing.Size(130, 30);
            this.txtSeatCount.TabIndex = 7;
            this.txtSeatCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSeatCount
            // 
            this.lblSeatCount.AutoSize = true;
            this.lblSeatCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSeatCount.ForeColor = System.Drawing.Color.White;
            this.lblSeatCount.Location = new System.Drawing.Point(508, 100);
            this.lblSeatCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeatCount.Name = "lblSeatCount";
            this.lblSeatCount.Size = new System.Drawing.Size(137, 23);
            this.lblSeatCount.TabIndex = 6;
            this.lblSeatCount.Text = "SỐ LƯỢNG GHẾ:";
            // 
            // cbCinema
            // 
            this.cbCinema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCinema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCinema.FormattingEnabled = true;
            this.cbCinema.Items.AddRange(new object[] {
            "Rạp 01 - Standard",
            "Rạp 02 - VIP",
            "Rạp 03 - IMAX"});
            this.cbCinema.Location = new System.Drawing.Point(513, 56);
            this.cbCinema.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCinema.Name = "cbCinema";
            this.cbCinema.Size = new System.Drawing.Size(274, 31);
            this.cbCinema.TabIndex = 5;
            // 
            // lblCinema
            // 
            this.lblCinema.AutoSize = true;
            this.lblCinema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCinema.ForeColor = System.Drawing.Color.White;
            this.lblCinema.Location = new System.Drawing.Point(403, 60);
            this.lblCinema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCinema.Name = "lblCinema";
            this.lblCinema.Size = new System.Drawing.Size(99, 23);
            this.lblCinema.TabIndex = 4;
            this.lblCinema.Text = "CHỌN RẠP:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(140, 127);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(232, 30);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(86, 130);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(44, 23);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "SĐT:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtName.Location = new System.Drawing.Point(140, 71);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(232, 30);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(34, 75);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(101, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "HỌ VÀ TÊN:";
            // 
            // pnlMovies
            // 
            this.pnlMovies.BackColor = System.Drawing.Color.White;
            this.pnlMovies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMovies.Controls.Add(this.lblMoviesTitle);
            this.pnlMovies.Controls.Add(this.flpMovieList);
            this.pnlMovies.Location = new System.Drawing.Point(41, 438);
            this.pnlMovies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMovies.Name = "pnlMovies";
            this.pnlMovies.Size = new System.Drawing.Size(1196, 367);
            this.pnlMovies.TabIndex = 3;
            // 
            // lblMoviesTitle
            // 
            this.lblMoviesTitle.AutoSize = true;
            this.lblMoviesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMoviesTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMoviesTitle.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblMoviesTitle.Location = new System.Drawing.Point(13, 6);
            this.lblMoviesTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoviesTitle.Name = "lblMoviesTitle";
            this.lblMoviesTitle.Size = new System.Drawing.Size(175, 28);
            this.lblMoviesTitle.TabIndex = 0;
            this.lblMoviesTitle.Text = "Phim Đang Chiếu";
            // 
            // flpMovieList
            // 
            this.flpMovieList.AutoScroll = true;
            this.flpMovieList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMovieList.Location = new System.Drawing.Point(0, 37);
            this.flpMovieList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flpMovieList.Name = "flpMovieList";
            this.flpMovieList.Size = new System.Drawing.Size(1195, 307);
            this.flpMovieList.TabIndex = 1;
            this.flpMovieList.WrapContents = false;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.progressBar1);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(0, 826);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(1260, 18);
            this.pnlProgress.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1260, 18);
            this.progressBar1.TabIndex = 0;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 844);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.pnlMovies);
            this.Controls.Add(this.pnlBooking);
            this.Controls.Add(this.lblBigTitle);
            this.Controls.Add(this.pnlConnection);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormClient";
            this.Text = "Client Booking - UIT Cinema";
            this.pnlConnection.ResumeLayout(false);
            this.pnlConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBooking.ResumeLayout(false);
            this.pnlBooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSeatCount)).EndInit();
            this.pnlMovies.ResumeLayout(false);
            this.pnlMovies.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBigTitle;
        private System.Windows.Forms.Panel pnlConnection;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Panel pnlBooking;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ComboBox cbCinema;
        private System.Windows.Forms.Label lblCinema;
        private System.Windows.Forms.Label lblSeatCount;
        private System.Windows.Forms.NumericUpDown txtSeatCount;
        private System.Windows.Forms.ComboBox cbMovie;
        private System.Windows.Forms.Label lblMovie;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Panel pnlMovies;
        private System.Windows.Forms.Label lblMoviesTitle;
        private System.Windows.Forms.FlowLayoutPanel flpMovieList;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private PictureBox pictureBox1;
    }
}
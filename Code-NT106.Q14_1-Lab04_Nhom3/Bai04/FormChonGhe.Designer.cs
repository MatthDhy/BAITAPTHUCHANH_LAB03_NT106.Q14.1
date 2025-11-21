using System.Drawing;
using System.Windows.Forms;

namespace Bai04
{
    partial class FormChonGhe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblScreen = new System.Windows.Forms.Label();
            this.pnlSeats = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblScreen
            // 
            this.lblScreen.BackColor = System.Drawing.Color.Gray;
            this.lblScreen.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblScreen.ForeColor = System.Drawing.Color.Black;
            this.lblScreen.Location = new System.Drawing.Point(75, 30);
            this.lblScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(750, 62);
            this.lblScreen.TabIndex = 0;
            this.lblScreen.Text = "MÀN HÌNH CHIẾU (SCREEN)";
            this.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSeats
            // 
            this.pnlSeats.BackColor = System.Drawing.Color.Transparent;
            this.pnlSeats.Location = new System.Drawing.Point(149, 158);
            this.pnlSeats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlSeats.Name = "pnlSeats";
            this.pnlSeats.Size = new System.Drawing.Size(648, 336);
            this.pnlSeats.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.Yellow;
            this.lblInfo.Location = new System.Drawing.Point(75, 523);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(279, 28);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Vui lòng chọn đủ số lượng vé...";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(75, 570);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(237, 38);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Tạm tính: 0 VNĐ";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Crimson;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(600, 538);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(225, 77);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "CHỌN GHẾ";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // FormChonGhe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 692);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pnlSeats);
            this.Controls.Add(this.lblScreen);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormChonGhe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Ghế - UIT Cinema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.FlowLayoutPanel pnlSeats;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnConfirm;
    }
}
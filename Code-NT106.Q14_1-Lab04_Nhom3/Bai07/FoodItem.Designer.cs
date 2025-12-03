namespace Bai07
{
    partial class FoodItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picFood = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblContributor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).BeginInit();
            this.SuspendLayout();
            // 
            // picFood
            // 
            this.picFood.Location = new System.Drawing.Point(10, 10);
            this.picFood.Name = "picFood";
            this.picFood.Size = new System.Drawing.Size(130, 130);
            this.picFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFood.TabIndex = 0;
            this.picFood.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Chocolate;
            this.lblName.Location = new System.Drawing.Point(150, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(128, 37);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên Món";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPrice.Location = new System.Drawing.Point(155, 55);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 23);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "Giá";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAddress.Location = new System.Drawing.Point(155, 85);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 23);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "Địa chỉ";
            // 
            // lblContributor
            // 
            this.lblContributor.AutoSize = true;
            this.lblContributor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblContributor.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblContributor.Location = new System.Drawing.Point(155, 115);
            this.lblContributor.Name = "lblContributor";
            this.lblContributor.Size = new System.Drawing.Size(75, 20);
            this.lblContributor.TabIndex = 4;
            this.lblContributor.Text = "Đóng góp:";
            // 
            // FoodItem
            // 
            this.Controls.Add(this.lblContributor);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picFood);
            this.Name = "FoodItem";
            this.Size = new System.Drawing.Size(580, 150);
            this.Load += new System.EventHandler(this.FoodItem_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.picFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFood;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblContributor;
    }
}
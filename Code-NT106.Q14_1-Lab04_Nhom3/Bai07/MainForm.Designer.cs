namespace Bai07
{
    partial class MainForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMyDishes = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.flpList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.cbPageSize = new System.Windows.Forms.ComboBox();
            this.pnlPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(302, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(300, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(0, 16);
            this.lblWelcome.TabIndex = 1;
            // 
            // btnAll
            // 
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Location = new System.Drawing.Point(20, 70);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(80, 30);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "All";
            // 
            // btnMyDishes
            // 
            this.btnMyDishes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyDishes.Location = new System.Drawing.Point(110, 70);
            this.btnMyDishes.Name = "btnMyDishes";
            this.btnMyDishes.Size = new System.Drawing.Size(120, 30);
            this.btnMyDishes.TabIndex = 3;
            this.btnMyDishes.Text = "Tôi đóng góp";
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnRandom.Location = new System.Drawing.Point(350, 60);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(100, 40);
            this.btnRandom.TabIndex = 4;
            this.btnRandom.Text = "Ăn gì giờ?";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnAdd.Location = new System.Drawing.Point(460, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Thêm món ăn";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // flpList
            // 
            this.flpList.AutoScroll = true;
            this.flpList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpList.Location = new System.Drawing.Point(20, 110);
            this.flpList.Name = "flpList";
            this.flpList.Size = new System.Drawing.Size(600, 400);
            this.flpList.TabIndex = 6;
            this.flpList.WrapContents = false;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Controls.Add(this.btnPrev);
            this.pnlPagination.Controls.Add(this.lblPage);
            this.pnlPagination.Controls.Add(this.btnNext);
            this.pnlPagination.Controls.Add(this.cbPageSize);
            this.pnlPagination.Location = new System.Drawing.Point(20, 520);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(600, 40);
            this.pnlPagination.TabIndex = 7;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(350, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 30);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(390, 10);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(14, 16);
            this.lblPage.TabIndex = 1;
            this.lblPage.Text = "1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(420, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">";
            // 
            // cbPageSize
            // 
            this.cbPageSize.FormattingEnabled = true;
            this.cbPageSize.Items.AddRange(new object[] {
            "5",
            "10",
            "20"});
            this.cbPageSize.Location = new System.Drawing.Point(500, 8);
            this.cbPageSize.Name = "cbPageSize";
            this.cbPageSize.Size = new System.Drawing.Size(50, 24);
            this.cbPageSize.TabIndex = 3;
            this.cbPageSize.Text = "5";
            this.cbPageSize.SelectedIndexChanged += new System.EventHandler(this.cbPageSize_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(660, 600);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.flpList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnMyDishes);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Name = "MainForm";
            this.Text = "Hôm nay ăn gì?";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlPagination.ResumeLayout(false);
            this.pnlPagination.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnMyDishes;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.ComboBox cbPageSize;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPage;
    }
}


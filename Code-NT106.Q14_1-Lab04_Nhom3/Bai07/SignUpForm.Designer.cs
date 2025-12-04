namespace Bai07
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lblHeader.Location = new System.Drawing.Point(120, 10);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(239, 37);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "HÔM NAY ĂN GÌ?";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.Location = new System.Drawing.Point(20, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Sign Up";
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.label3);
            this.groupBoxInfo.Controls.Add(this.txtEmail);
            this.groupBoxInfo.Controls.Add(this.label4);
            this.groupBoxInfo.Controls.Add(this.txtFirstName);
            this.groupBoxInfo.Controls.Add(this.label5);
            this.groupBoxInfo.Controls.Add(this.txtLastName);
            this.groupBoxInfo.Controls.Add(this.label6);
            this.groupBoxInfo.Controls.Add(this.txtPhone);
            this.groupBoxInfo.Controls.Add(this.label7);
            this.groupBoxInfo.Controls.Add(this.dtpBirthday);
            this.groupBoxInfo.Controls.Add(this.label8);
            this.groupBoxInfo.Controls.Add(this.txtLanguage);
            this.groupBoxInfo.Controls.Add(this.label9);
            this.groupBoxInfo.Controls.Add(this.radMale);
            this.groupBoxInfo.Controls.Add(this.radFemale);
            this.groupBoxInfo.Location = new System.Drawing.Point(20, 140);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(350, 280);
            this.groupBoxInfo.TabIndex = 6;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "User Information";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(90, 27);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Firstname";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(90, 57);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(240, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Lastname";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(90, 87);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(240, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 117);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(240, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 23);
            this.label7.TabIndex = 8;
            this.label7.Text = "Birthday";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthday.Location = new System.Drawing.Point(90, 147);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(240, 22);
            this.dtpBirthday.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Language";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(90, 177);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(240, 22);
            this.txtLanguage.TabIndex = 11;
            this.txtLanguage.Text = "vi";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(0, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Sex";
            // 
            // radMale
            // 
            this.radMale.Checked = true;
            this.radMale.Location = new System.Drawing.Point(90, 207);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(104, 24);
            this.radMale.TabIndex = 13;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            // 
            // radFemale
            // 
            this.radFemale.Location = new System.Drawing.Point(215, 210);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(85, 24);
            this.radFemale.TabIndex = 14;
            this.radFemale.Text = "Female";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(127, 77);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(243, 22);
            this.txtUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(127, 107);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(243, 22);
            this.txtPass.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(290, 440);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(200, 440);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            // 
            // SignUpForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 500);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hôm nay ăn gì? - Signup";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1, label2, label3, label4, label5, label6, label7, label8, label9;
        private System.Windows.Forms.TextBox txtUser, txtPass, txtEmail, txtFirstName, txtLastName, txtPhone, txtLanguage;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.RadioButton radMale, radFemale;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Button btnSubmit, btnClear;
    }
}
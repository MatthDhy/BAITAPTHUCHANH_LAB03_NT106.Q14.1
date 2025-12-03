using Bai07.Models;
using Bai07;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai07.Models;

namespace Bai07
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
            this.lnkSignup.LinkClicked += lnkSignup_LinkClicked;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Tạo data form-data theo yêu cầu bài Lab
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(username), "username");
                    content.Add(new StringContent(password), "password");

                    // Gửi request POST
                    string url = $"{AuthGlobal.BaseUrl}/auth/token";
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    string responseString = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(responseString);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lấy token thành công
                        AuthGlobal.AccessToken = responseObject["access_token"].ToString();
                        AuthGlobal.CurrentUsername = username;

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo");

                        // Mở MainForm và ẩn Login
                        MainForm main = new MainForm();
                        this.Hide();
                        main.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        string detail = responseObject["detail"]?.ToString() ?? "Lỗi không xác định";
                        MessageBox.Show($"Đăng nhập thất bại: {detail}", "Lỗi");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối: {ex.Message}");
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void lnkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUp = new SignUpForm();
            signUp.ShowDialog();
        }
    }
}

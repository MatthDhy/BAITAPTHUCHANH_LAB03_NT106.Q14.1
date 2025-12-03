using Bai07.Models;
using Newtonsoft.Json;
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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            btnSubmit.Click += btnSubmit_Click;
            btnClear.Click += (s, e) => {
                txtUser.Clear(); txtPass.Clear(); txtEmail.Clear();
                txtFirstName.Clear(); txtLastName.Clear(); txtPhone.Clear();
            };
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Vui lòng nhập Username và Password!");
                return;
            }

            // 2. Tạo đối tượng UserSignup từ giao diện
            UserSignup newUser = new UserSignup()
            {
                username = txtUser.Text,
                password = txtPass.Text,
                email = txtEmail.Text,
                first_name = txtFirstName.Text,
                last_name = txtLastName.Text,
                phone = txtPhone.Text,
                language = txtLanguage.Text,
                birthday = dtpBirthday.Value.ToString("yyyy-MM-dd"), // Định dạng ngày cho API
                sex = radMale.Checked ? 1 : 0
            };

            // 3. Gọi API đăng ký
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Chuyển đối tượng thành JSON
                    string json = JsonConvert.SerializeObject(newUser);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Đường dẫn API đăng ký (Dựa trên tài liệu bài Lab, thường là /api/v1/user)
                    string url = $"{AuthGlobal.BaseUrl}/api/v1/user/signup";

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.");
                        this.Close(); // Đóng form đăng ký để quay lại Login
                    }
                    else
                    {
                        // Đọc lỗi từ Server trả về
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Đăng ký thất bại: {errorResponse}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; // Thư viện xử lý JSON 

namespace Lab4_Bai5
{
    public partial class Bai05 : Form
    {
        public Bai05()
        {
            InitializeComponent();
            StyleUI(); 
        }

        // --- PHẦN 1: LOGIC GỬI REQUEST (QUAN TRỌNG NHẤT) ---

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin từ giao diện
            string url = txtUrl.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                rtbResponse.Text = "Vui lòng nhập đầy đủ Username và Password!";
                return;
            }

            rtbResponse.Text = "Đang kết nối đến Server...";
            btnLogin.Enabled = false; // Khóa nút để tránh spam click

            try
            {
                [cite_start]// 2. Khởi tạo HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    [cite_start]// 3. Tạo MultipartFormDataContent (theo yêu cầu Lab) [cite: 501]
                    MultipartFormDataContent content = new MultipartFormDataContent();
                    content.Add(new StringContent(username), "username");
                    content.Add(new StringContent(password), "password");

                    [cite_start]// 4. Gửi POST request [cite: 505]
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    // 5. Đọc nội dung trả về
                    string responseString = await response.Content.ReadAsStringAsync(); // [cite: 506]

                    // Parse JSON để xử lý dữ liệu
                    JObject json = JObject.Parse(responseString); // 

                    rtbResponse.Clear(); // Xóa log cũ

                    [cite_start]// 6. Kiểm tra kết quả [cite: 508]
                    if (response.IsSuccessStatusCode)
                    {
                        [cite_start]// THÀNH CÔNG [cite: 464]
                        string tokenType = json["token_type"].ToString();
                        string accessToken = json["access_token"].ToString();

                        rtbResponse.SelectionColor = Color.Green;
                        rtbResponse.AppendText("ĐĂNG NHẬP THÀNH CÔNG!\n\n");

                        rtbResponse.SelectionColor = Color.Black;
                        rtbResponse.AppendText($"Token Type: {tokenType}\n");
                        rtbResponse.AppendText($"Access Token: {accessToken}\n");

                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        [cite_start]// THẤT BẠI [cite: 467]
                        string detail = json["detail"] != null ? json["detail"].ToString() : "Lỗi không xác định";

                        rtbResponse.SelectionColor = Color.Red;
                        rtbResponse.AppendText("ĐĂNG NHẬP THẤT BẠI!\n\n");
                        rtbResponse.AppendText($"Lỗi: {detail}");

                        MessageBox.Show($"Đăng nhập thất bại: {detail}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                rtbResponse.Text = "Lỗi ứng dụng: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true; // Mở lại nút
            }
        }

        // --- PHẦN 2: TRANG TRÍ GIAO DIỆN HIỆN ĐẠI (DESIGNER CODE) ---
        // Hàm này code tay để ghi đè giao diện mặc định của WinForms
        private void StyleUI()
        {
            // Màu sắc chủ đạo (Modern Blue & Clean White)
            Color primaryColor = Color.FromArgb(52, 152, 219); // Xanh dương phẳng
            Color hoverColor = Color.FromArgb(41, 128, 185);
            Color bgColor = Color.White;
            Color inputBg = Color.FromArgb(245, 245, 245); // Xám cực nhạt cho ô nhập
            Font mainFont = new Font("Segoe UI", 10, FontStyle.Regular);
            Font headerFont = new Font("Segoe UI", 12, FontStyle.Bold);

            // Cấu hình Form
            this.Text = "Lab 4 - Bài 5: Login API";
            this.BackColor = bgColor;
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Helper để style Textbox
            void StyleBox(TextBox tb)
            {
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.BackColor = inputBg;
                tb.Font = mainFont;
                tb.Padding = new Padding(5);
                tb.Height = 30; // Hack chiều cao cho đẹp
            }

            // Áp dụng Style cho các control
            if (txtUrl != null) { StyleBox(txtUrl); txtUrl.Text = "https://nt106.uitiot.vn/auth/token"; }
            if (txtUsername != null) StyleBox(txtUsername);
            if (txtPassword != null) StyleBox(txtPassword);

            // Style nút bấm (Button)
            if (btnLogin != null)
            {
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.BackColor = primaryColor;
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatAppearance.BorderSize = 0;
                btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                btnLogin.Cursor = Cursors.Hand;
                btnLogin.Text = "ĐĂNG NHẬP (LOGIN)";

                // Hiệu ứng hover chuột
                btnLogin.MouseEnter += (s, e) => btnLogin.BackColor = hoverColor;
                btnLogin.MouseLeave += (s, e) => btnLogin.BackColor = primaryColor;
            }

            // Style khung hiển thị kết quả (RichTextBox)
            if (rtbResponse != null)
            {
                rtbResponse.BackColor = Color.FromArgb(40, 44, 52); // Màu nền tối kiểu Code Editor
                rtbResponse.ForeColor = Color.FromArgb(171, 178, 191); // Màu chữ sáng
                rtbResponse.Font = new Font("Consolas", 10);
                rtbResponse.BorderStyle = BorderStyle.None;
            }
        }
    }
}
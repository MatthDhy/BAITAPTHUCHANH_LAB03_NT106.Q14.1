using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Bai07.Models; // Đảm bảo bạn đã có folder Models và namespace đúng

namespace Bai07
{
    public partial class AddDishForm : Form
    {
        public AddDishForm()
        {
            InitializeComponent();

            // Xử lý sự kiện nút Clear
            btnClear.Click += (s, e) => {
                txtName.Clear();
                txtPrice.Clear();
                txtAddress.Clear();
                txtImage.Clear();
                txtDesc.Clear();
            };
        }

        // ĐÂY LÀ HÀM BẠN ĐANG BỊ THIẾU
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món và giá!");
                return;
            }

            // 2. Tạo object món ăn (khớp với API Swagger)
            Dish newDish = new Dish()
            {
                ten_mon_an = txtName.Text,

                // Xử lý giá tiền (nếu nhập sai định dạng số thì về 0)
                gia = double.TryParse(txtPrice.Text, out double p) ? p : 0,

                dia_chi = txtAddress.Text,
                hinh_anh = txtImage.Text,
                mo_ta = txtDesc.Text
            };

            // 3. Gọi API thêm món
            using (HttpClient client = new HttpClient())
            {
                // Thêm Token vào Header (nhớ class AuthGlobal phải đổi namespace sang Bai07 nếu cần)
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AuthGlobal.AccessToken);

                try
                {
                    string json = JsonConvert.SerializeObject(newDish);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // URL API thêm món (theo tài liệu Swagger mới nhất)
                    string url = $"{AuthGlobal.BaseUrl}/api/v1/monan/add";

                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Thêm món ăn thành công!");
                        this.DialogResult = DialogResult.OK; // Báo về MainForm để load lại
                        this.Close();
                    }
                    else
                    {
                        string err = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Thêm thất bại! Lỗi: " + response.StatusCode + "\n" + err);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai07.Models;
using Bai07.Models;
using Bai07;

namespace Bai07
{
    public partial class MainForm : Form
    {
        private int currentPage = 1;
        private int pageSize = 5;
        private List<Dish> currentListDish = new List<Dish>();
        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            btnNext.Click += (s, e) => ChangePage(1);
            btnPrev.Click += (s, e) => ChangePage(-1);
            btnAdd.Click += btnAdd_Click;
            btnRandom.Click += btnRandom_Click;
            btnMyDishes.Click += (s, e) => LoadDishes(true); // Lọc món của tôi
            btnAll.Click += (s, e) => LoadDishes(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (currentListDish.Count > 0)
            {
                Random rnd = new Random();
                int index = rnd.Next(currentListDish.Count);
                Dish luckyDish = currentListDish[index];

                MessageBox.Show($"Hôm nay ăn: {luckyDish.ten_mon_an}\nĐịa chỉ: {luckyDish.dia_chi}", "Kết quả Random");
            }
            else
            {
                MessageBox.Show("Không có món ăn nào trong danh sách để chọn!");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {AuthGlobal.CurrentUsername}";
            LoadDishes();
        }

        private async void LoadDishes(bool isMyDish = false)
        {
            flpList.Controls.Clear();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", AuthGlobal.AccessToken);

                try
                {
                    HttpResponseMessage response;

                    if (isMyDish)
                    {

                        string url = $"{AuthGlobal.BaseUrl}/api/v1/monan/my-dishes";
                        response = await client.PostAsync(url, null); // Doc ghi POST nhưng không param? Hãy thử POST không body hoặc check lại kỹ. 
                        var paginationData = new { current = currentPage, pageSize = pageSize };
                        string jsonContent = JsonConvert.SerializeObject(paginationData);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        response = await client.PostAsync(url, content);
                    }
                    else
                    {
                        string url = $"{AuthGlobal.BaseUrl}/api/v1/monan/all";

                        // Tạo body cho request POST
                        var paginationData = new { current = currentPage, pageSize = pageSize };
                        string jsonContent = JsonConvert.SerializeObject(paginationData);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        // Gọi POST thay vì GET
                        response = await client.PostAsync(url, content);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PaginationResult<Dish>>(json);

                        if (result != null && result.data != null)
                        {
                            currentListDish = result.data;
                            lblPage.Text = currentPage.ToString();

                            foreach (var dish in result.data)
                            {
                                FoodItem itemControl = new FoodItem();
                                itemControl.SetData(
                                    dish.ten_mon_an,
                                    dish.gia.ToString(),
                                    dish.dia_chi,
                                    dish.nguoi_dong_gop,
                                    dish.hinh_anh
                                );
                                flpList.Controls.Add(itemControl);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
                }
            }
        }

        private void ChangePage(int delta)
        {
            if (currentPage + delta > 0)
            {
                currentPage += delta;
                LoadDishes();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDishForm addForm = new AddDishForm();
            // Khi đóng form thêm, load lại danh sách để cập nhật món mới
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadDishes();
            }
        }

        private void flpList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

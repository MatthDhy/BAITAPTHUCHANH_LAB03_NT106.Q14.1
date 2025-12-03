using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class FoodItem : UserControl
    {
        public FoodItem()
        {
            InitializeComponent();

            // Các thiết lập thêm cho UserControl
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(0, 0, 0, 10);
        }

        public void SetData(string name, string price, string address, string contributor, string imageUrl)
        {
            lblName.Text = name;
            lblPrice.Text = $"{double.Parse(price):N0} VNĐ"; // Định dạng tiền tệ
            lblAddress.Text = address;
            lblContributor.Text = $"Đóng góp: {contributor}";

            // Load ảnh từ URL
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    picFood.LoadAsync(imageUrl); // Load ảnh bất đồng bộ để không đơ form
                }
                catch
                {
                    // Nếu lỗi link ảnh thì bỏ qua hoặc load ảnh mặc định
                }
            }
        }

        private void FoodItem_Load(object sender, EventArgs e)
        {

        }

        private void FoodItem_Load_1(object sender, EventArgs e)
        {

        }
    }
}

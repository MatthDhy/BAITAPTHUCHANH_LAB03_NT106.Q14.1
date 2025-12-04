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
            if (!string.IsNullOrEmpty(imageUrl) && (imageUrl.StartsWith("http://") || imageUrl.StartsWith("https://")))
            {
                try
                {
                    // Load ảnh bất đồng bộ (không làm đơ ứng dụng)
                    picFood.LoadAsync(imageUrl);
                }
                catch
                {
                    // Nếu link lỗi, load ảnh mặc định hoặc để trống
                    // picFood.Image = Properties.Resources.default_food; // (Nếu bạn có ảnh mặc định)
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

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class FormInput : Form
    {
        private string author;
        private NetworkStream ns;
        public FormInput(string author, NetworkStream ns)
        {
            InitializeComponent();
            this.author = author;
            this.ns = ns;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ảnh (*.png;*.jpg)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImagePath.Text = ofd.FileName;
                picPreview.ImageLocation = ofd.FileName;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text.Trim();
            string img = txtImagePath.Text.Trim();
            if (name == "" || !File.Exists(img))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và chọn ảnh hợp lệ!");
                return;
            }
            string msg = $"addfood|{name}|{img}";
            byte[] data = Encoding.UTF8.GetBytes(msg);
            await ns.WriteAsync(data, 0, data.Length);
            txtFoodName.Clear();
            txtImagePath.Clear();
            picPreview.Image = null;
            MessageBox.Show("Đã thêm món ăn!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

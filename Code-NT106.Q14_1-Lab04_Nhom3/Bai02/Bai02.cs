using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;

namespace Bai02
{
    public partial class Bai02: Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();
            string filePath = txtFilePath.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn file lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (WebClient client = new WebClient())
                {
                    if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    {
                        url = "http://" + url;
                    }

                    lblStatus.Text = "Đang tải dữ liệu...";
                    lblStatus.Visible = true;

                    client.DownloadFile(url, filePath);

                    string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);
                    txtHTML.Text = htmlContent;
                    
                    MessageBox.Show("Download thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi download: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblStatus.Visible = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Vui lòng nhập URL trước khi chọn nơi lưu file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                url = "http://" + url;

            Uri uri = new Uri(url);
            string host = uri.Host.Split('.')[0]; 
            string fileName = host + ".html";     

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "HTML Files|*.html;*.htm|All Files|*.*";
            sfd.Title = "Chọn nơi lưu file HTML";
            sfd.FileName = fileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = sfd.FileName;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtURL.Clear();
            txtFilePath.Clear();
            txtHTML.Clear();
            txtURL.Focus();
        }

        
    }
}

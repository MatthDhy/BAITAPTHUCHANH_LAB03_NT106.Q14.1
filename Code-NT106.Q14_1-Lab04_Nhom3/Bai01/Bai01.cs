using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Bai01: Form
    {
        public Bai01()
        {
            InitializeComponent();
        }
        private string getHTML(string szURL)
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(szURL);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Close the response.
            response.Close();
            return responseFromServer;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtURL.Text.Trim();
                
                if (string.IsNullOrEmpty(url))
                {
                    MessageBox.Show("Vui lòng nhập URL!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }

                lblStatus.Text = "Đang tải dữ liệu...";
                lblStatus.Visible = true;

                string htmlContent = getHTML(url);
                txtHTML.Text = htmlContent;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lblStatus.Visible = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtURL.Clear();
            txtHTML.Clear();
            txtURL.Focus();
        }
    }
}

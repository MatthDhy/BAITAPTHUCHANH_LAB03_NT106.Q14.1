using System;
using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using System.Net.Http;
using HtmlAgilityPack;
using System.Security.Policy;

namespace Bai03
{
    public partial class Bai03: Form
    {
        public Bai03()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.NavigationStarting += EnsureHttps;
            InitializeAsync();
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            btnLoad.Left = this.ClientSize.Width - btnLoad.Width;
            txtAddress.Width = btnLoad.Left - txtAddress.Left;
        }
        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            txtAddress.Text = uri;
            webView.CoreWebView2.PostWebMessageAsString(uri);
        }
        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }
        private bool CheckUrl()
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text == "about:blank")
            {
                MessageBox.Show("Vui lòng nhập URL trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!CheckUrl()) return;
            if (webView.CoreWebView2 == null) return;

            try
            {
                string url = txtAddress.Text;

                if (!url.StartsWith("http://") && !url.StartsWith("https://")) 
                { 
                    url = "https://" + url; 
                }
                if (webView != null && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Navigate(url);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (!CheckUrl()) return;
            if (webView.CoreWebView2 == null) return;

            try
            {

                if (webView != null && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDownFile_Click(object sender, EventArgs e)
        {
            if (!CheckUrl()) return;
            if (webView.CoreWebView2 == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML file|*.html";
                sfd.FileName = "page.html";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string html = await webView.CoreWebView2.ExecuteScriptAsync(
                        "document.documentElement.outerHTML;"
                    );

                    html = System.Text.Json.JsonSerializer.Deserialize<string>(html);

                    System.IO.File.WriteAllText(sfd.FileName, html, Encoding.UTF8);

                    MessageBox.Show("Tải file HTML thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải HTML: " + ex.Message);
                }
            }
        }


        private async void btnDownSource_Click(object sender, EventArgs e)
        {
            if (!CheckUrl()) return;
            if (webView.CoreWebView2 == null) return;

            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục lưu ảnh";

                if (fbd.ShowDialog() != DialogResult.OK) return;
                string folder = fbd.SelectedPath;

                try
                {
                    // Lấy HTML
                    string html = await webView.CoreWebView2.ExecuteScriptAsync(
                        "document.documentElement.outerHTML;"
                    );
                    html = System.Text.Json.JsonSerializer.Deserialize<string>(html);

                    // Parse bằng HTMLAgilityPack
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    var imgs = doc.DocumentNode.SelectNodes("//img[@src]");
                    if (imgs == null)
                    {
                        MessageBox.Show("Không tìm thấy hình nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    int success = 0, fail = 0;

                    using (HttpClient client = new HttpClient())
                    {
                        foreach (var img in imgs)
                        {
                            string src = img.GetAttributeValue("src", "");

                            // Xử lý URL tương đối
                            Uri baseUri = new Uri(txtAddress.Text);
                            Uri absUri = new Uri(baseUri, src);

                            try
                            {
                                byte[] data = await client.GetByteArrayAsync(absUri);

                                string fileName = System.IO.Path.GetFileName(absUri.LocalPath);
                                if (string.IsNullOrEmpty(fileName))
                                    fileName = Guid.NewGuid().ToString() + ".jpg";

                                string savePath = System.IO.Path.Combine(folder, fileName);

                                System.IO.File.WriteAllBytes(savePath, data);
                                success++;
                            }
                            catch
                            {
                                fail++;
                            }
                        }
                    }

                    MessageBox.Show($"Download hoàn tất!\nThành công: {success}\nThất bại: {fail}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải resource: " + ex.Message);
                }
            }
        }

        private async void btnViewSource_Click(object sender, EventArgs e)
        {
            if (!CheckUrl()) return;
            if (webView.CoreWebView2 == null) return;

            try
            {
                // Lấy mã nguồn HTML của trang web hiện tại
                string html = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML;");
                html = System.Text.Json.JsonSerializer.Deserialize<string>(html);

                // Mở form mới để hiển thị mã nguồn HTML
                SourceForm sourceForm = new SourceForm(html);
                sourceForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã nguồn HTML: " + ex.Message);
            }
        }


    }
}

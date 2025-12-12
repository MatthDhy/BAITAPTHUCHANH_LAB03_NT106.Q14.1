using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Bai04
{
    public partial class FormBrowser : Form
    {
        private WebView2 webView;
        private string _url;

        public FormBrowser(string url)
        {
            _url = url;
            InitializeComponent(); // Hàm này để nguyên, nó gọi từ file Designer qua
            SetupBrowser();
        }

        private async void SetupBrowser()
        {
            // Code tạo trình duyệt giữ nguyên như cũ
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            this.Controls.Add(webView);

            await webView.EnsureCoreWebView2Async(null);

            if (!string.IsNullOrEmpty(_url))
            {
                webView.CoreWebView2.Navigate(_url);
            }
        }
    }
}
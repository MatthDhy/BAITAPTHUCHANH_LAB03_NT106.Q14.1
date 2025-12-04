using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class UserForm : Form
    {
        private readonly string tokenType;
        private readonly string accessToken;

        public UserForm(string tType, string aToken)
        {
            InitializeComponent();
            tokenType = tType;
            accessToken = aToken;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            // Load API docs bằng WebView2
            await webView.EnsureCoreWebView2Async();
            webView.Source = new Uri("https://nt106.uitiot.vn/docs");

            // Load user info
            await LoadUserInfo();
        }

        private async Task LoadUserInfo()
        {
            string url = "https://nt106.uitiot.vn/api/v1/user/me";

            rtbLog.Clear();
            rtbLog.AppendText("=== REQUEST ===\n");
            rtbLog.AppendText("GET " + url + "\n");
            rtbLog.AppendText("Authorization: " + tokenType + " " + accessToken + "\n\n");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, accessToken);

                try
                {
                    var response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();

                    rtbLog.AppendText("=== RESPONSE ===\n" + json + "\n\n");

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Server Error:\n" + json);
                        return;
                    }

                    var obj = JObject.Parse(json);

                    // Basic fields
                    txtId.Text = obj["id"]?.ToString();
                    txtUsername.Text = obj["username"]?.ToString();
                    txtFullname.Text = obj["full_name"]?.ToString();
                    txtEmail.Text = obj["email"]?.ToString();

                    // Avatar
                    string avatarUrl = obj["avatar"]?.ToString();

                    if (!string.IsNullOrEmpty(avatarUrl))
                    {
                        using (var wc = new WebClient())
                        {
                            byte[] data = wc.DownloadData(avatarUrl);
                            using (var ms = new System.IO.MemoryStream(data))
                            {
                                picAvatar.Image = System.Drawing.Image.FromStream(ms);
                            }
                        }
                    }
                    else
                    {
                        picAvatar.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    rtbLog.AppendText("Error: " + ex.Message);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadUserInfo();
        }
    }
}

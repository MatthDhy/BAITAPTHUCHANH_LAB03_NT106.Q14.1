using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class LoginForm : Form
    {
        private string lastTokenType = "";
        private string lastAccessToken = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            var url = "https://nt106.uitiot.vn/auth/token";

            using (var client = new HttpClient())
            {
                var form = new MultipartFormDataContent
                {
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" }
                };

                var response = await client.PostAsync(url, form);
                string json = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(json);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(obj["detail"].ToString(), "Login Failed");
                    return;
                }

                lastTokenType = obj["token_type"].ToString();
                lastAccessToken = obj["access_token"].ToString();

                // Mở UserForm
                UserForm uf = new UserForm(lastTokenType, lastAccessToken);
                uf.Show();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lastAccessToken))
            {
                Clipboard.SetText(lastAccessToken);
                MessageBox.Show("Copied!");
            }
        }
    }
}

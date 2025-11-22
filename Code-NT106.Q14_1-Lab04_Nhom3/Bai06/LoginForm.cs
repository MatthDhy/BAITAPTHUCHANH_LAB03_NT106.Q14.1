using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Bai06
{
    public partial class LoginForm : Form
    {
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
                var json = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(json);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(obj["detail"].ToString(), "Login failed");
                    return;
                }

                string tokenType = obj["token_type"].ToString();
                string accessToken = obj["access_token"].ToString();

                // Mở UserForm & truyền token
                UserForm uf = new UserForm(tokenType, accessToken);
                uf.Show();
            }
        }

    }
}

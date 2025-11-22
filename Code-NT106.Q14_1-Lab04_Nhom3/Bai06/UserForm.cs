using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class UserForm : Form
    {
        private string tokenType;
        private string accessToken;

        public UserForm(string tType, string aToken)
        {
            InitializeComponent();
            tokenType = tType;
            accessToken = aToken;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            await LoadUserInfo();
        }

        private async Task LoadUserInfo()
        {
            var url = "https://nt106.uitiot.vn/api/v1/user/me";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(tokenType, accessToken);

                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(json);

                txtId.Text = obj["id"]?.ToString();
                txtUsername.Text = obj["username"]?.ToString();
                txtFullname.Text = obj["full_name"]?.ToString();
                txtEmail.Text = obj["email"]?.ToString();
            }
        }

    }
}

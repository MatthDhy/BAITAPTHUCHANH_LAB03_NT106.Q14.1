using System;
using System.Windows.Forms;

namespace Bai04
{
    public partial class FormDashboard : BaseForm
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            FormServer server = new FormServer();
            server.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient client = new FormClient();
            client.Show();
        }

    }
}
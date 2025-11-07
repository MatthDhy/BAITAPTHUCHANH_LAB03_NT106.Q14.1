using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class FormMain: Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient client = new FormClient();
            client.Show();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            FormServer server = new FormServer();
            server.Show();
        }
    }
}

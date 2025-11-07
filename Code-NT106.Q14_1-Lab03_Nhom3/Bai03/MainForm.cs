using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class MainForm : Form
    {
        public MainForm()
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

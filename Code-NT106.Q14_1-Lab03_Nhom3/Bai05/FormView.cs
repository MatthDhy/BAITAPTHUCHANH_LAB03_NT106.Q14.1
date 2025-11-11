using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class FormView : Form
    {

        private readonly string connStr = "Data Source=Database/monan.db";
        public FormView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists("Database/monan.db"))
            {
                MessageBox.Show("Chưa có database, hãy mở Server trước!");
                return;
            }

            using (var conn = new SQLiteConnection(connStr))
            {
                conn.Open();

                using (var da = new SQLiteDataAdapter("SELECT Name, Author FROM Food", conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvFoodList.DataSource = dt;    
                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

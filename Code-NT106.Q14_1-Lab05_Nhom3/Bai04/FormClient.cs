using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static Bai04.FormClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai04
{
    public partial class FormClient : BaseForm
    {
        // Class lưu thông tin phim
        public class Movie
        {
            public string Title { get; set; }
            public string ImageUrl { get; set; }
            public string DetailUrl { get; set; }
        }

        // Danh sách chứa 3 phim cố định
        List<Movie> myMovies = new List<Movie>();

        public FormClient()
        {
            InitializeComponent();

            // 1. Setup ComboBox chọn rạp/phim
            SetupComboBoxData();

            // 2. Chạy tiến trình "Giả lập" tải phim
            Task.Run(() => LoadMyMovies());
        }

        void SetupComboBoxData()
        {
            cbCinema.Items.Clear();
            cbCinema.Items.Add("Rạp Thủ Đức");
            cbCinema.Items.Add("Rạp Quận 2");
            cbCinema.Items.Add("Rạp Quận 1");
            cbCinema.SelectedIndex = 0;

            cbMovie.Items.Clear();
            cbMovie.Items.Add("Truy tìm long diên hương");
            cbMovie.Items.Add("Cải mã");
            cbMovie.Items.Add("Cưới vợ cho cha");
            cbMovie.SelectedIndex = 0;
        }

        // --- HÀM LOAD PHIM ---
        void LoadMyMovies()
        {
            myMovies.Clear();

            UpdateProgress(10);
            Thread.Sleep(500);

            // --- Tạo dữ liệu phim ---
            myMovies.Add(new Movie()
            {
                Title = "Truy tìm long diên hương",
                ImageUrl = "https://files.betacorp.vn/media%2fimages%2f2025%2f10%2f22%2ftruy%2Dtim%2Dlong%2Ddien%2Dhuong%2Dpayoff%2Dposter%2Dkthuoc%2Dsocial%2D140113%2D221025%2D54.jpg",
                DetailUrl = "https://betacinemas.vn/chi-tiet-phim.htm?gf=f806bb88-9afc-4a8b-a0fe-089038eed097"
            });
            UpdateProgress(40);
            Thread.Sleep(600);

            myMovies.Add(new Movie()
            {
                Title = "Cải mã",
                ImageUrl = "https://files.betacorp.vn/media%2fimages%2f2025%2f10%2f22%2fcai%2Dma%2Dposter%2D2%2Dkc%2D31102025%2D141554%2D221025%2D77.png",
                DetailUrl = "https://betacinemas.vn/chi-tiet-phim.htm?gf=8fd872c9-dbb9-4fee-9db9-5d5a1003d2c1"
            });
            UpdateProgress(70);
            Thread.Sleep(600);

            myMovies.Add(new Movie()
            {
                Title = "Cưới vợ cho cha",
                ImageUrl = "https://files.betacorp.vn/media%2fimages%2f2025%2f11%2f04%2fcuoi%2Dvo%2Dcho%2Dcha%2Dposter%2D171438%2D041125%2D71.png",
                DetailUrl = "https://betacinemas.vn/chi-tiet-phim.htm?gf=bc536e60-8d5b-4d88-b96d-537191fd41a8"
            });
            UpdateProgress(90);
            Thread.Sleep(300);

            // Lưu JSON
            string json = JsonConvert.SerializeObject(myMovies, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("movies.json", json);

            UpdateProgress(100);

            // Hiển thị lên giao diện
            this.Invoke(new Action(() => {
                BindMoviesToPanel();
            }));
        }

        void UpdateProgress(int val)
        {
            if (progressBar1.InvokeRequired)
                progressBar1.Invoke(new Action<int>(UpdateProgress), val);
            else
                progressBar1.Value = val;
        }

        // --- API ---
        void BindMoviesToPanel()
        {
            flpMovieList.Controls.Clear();

            foreach (var movie in myMovies)
            {
                // 1. Tạo Panel chứa
                Panel pnlItem = new Panel();
                pnlItem.Width = flpMovieList.Width - 25;
                pnlItem.Height = 110;
                pnlItem.BackColor = Color.White;
                pnlItem.BorderStyle = BorderStyle.FixedSingle;
                pnlItem.Margin = new Padding(5);
                pnlItem.Cursor = Cursors.Hand;

                // 2. Tạo PictureBox
                PictureBox pbPoster = new PictureBox();
                pbPoster.Size = new Size(70, 95);
                pbPoster.Location = new Point(5, 5);
                pbPoster.BackColor = Color.Gray;
                pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;

                if (!string.IsNullOrEmpty(movie.ImageUrl))
                {
                    try
                    {
                        // LoadAsync giúp tải ảnh mượt mà không bị đơ form
                        pbPoster.LoadAsync(movie.ImageUrl);
                    }
                    catch
                    {
                        // Nếu link ảnh lỗi thì để màu xám
                        pbPoster.BackColor = Color.Gray;
                    }
                }

                // 3. Tạo Label Tên phim
                Label lblTitle = new Label();
                lblTitle.Text = movie.Title;
                lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblTitle.ForeColor = Color.Chocolate;
                lblTitle.Location = new Point(85, 10);
                lblTitle.AutoSize = true;

                // 4. Tạo Label Link
                Label lblLink = new Label();
                lblLink.Text = movie.DetailUrl;
                lblLink.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblLink.ForeColor = Color.Blue; // Đổi màu xanh cho giống link
                lblLink.Font = new Font("Segoe UI", 9, FontStyle.Underline); // Gạch chân
                lblLink.Location = new Point(85, 40);
                lblLink.AutoSize = true;

                // --- PHẦN QUAN TRỌNG: SỰ KIỆN CLICK ---
                EventHandler openWeb = (s, e) => {
                    // 1. Tự động chọn phim trên ComboBox (Tiện lợi)
                    cbMovie.SelectedItem = movie.Title;

                    // 2. MỞ TRÌNH DUYỆT WEB (Đây là cái bạn cần nè)
                    if (!string.IsNullOrEmpty(movie.DetailUrl))
                    {
                        // Mở FormBrowser (Cái form nhúng web mình vừa tạo)
                        FormBrowser browser = new FormBrowser(movie.DetailUrl);
                        browser.Show();
                    }
                    else
                    {
                        MessageBox.Show("Phim này chưa có link chi tiết!");
                    }
                };

                // Gắn sự kiện này cho tất cả thành phần
                pnlItem.Click += openWeb;
                lblTitle.Click += openWeb;
                pbPoster.Click += openWeb;
                lblLink.Click += openWeb;

                // Thêm vào Panel
                pnlItem.Controls.Add(pbPoster);
                pnlItem.Controls.Add(lblTitle);
                pnlItem.Controls.Add(lblLink);
                flpMovieList.Controls.Add(pnlItem);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(txtServerIP.Text, int.Parse(txtPort.Text));
                MessageBox.Show("Kết nối Server thành công!", "Thông báo");
                client.Close();

                btnBook.Enabled = true;
                btnBook.BackColor = Color.OrangeRed;
                pnlConnection.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Không tìm thấy Server!", "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Email!", "Cảnh báo");
                return;
            }

            string name = txtName.Text;
            string email = txtEmail.Text;
            string movie = cbMovie.Text;
            string cinema = cbCinema.Text;
            int seatCount = (int)txtSeatCount.Value;

            string ip = txtServerIP.Text;
            int port = int.Parse(txtPort.Text);

            string posterUrl = "";
            foreach (var m in myMovies)
            {
                if (m.Title == movie)
                {
                    posterUrl = m.ImageUrl;
                    break;
                }
            }

            string bookedSeats = "";
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, port);

                // Gửi yêu cầu
                byte[] request = Encoding.UTF8.GetBytes("GET_BOOKED_SEATS");
                NetworkStream stream = client.GetStream();
                stream.Write(request, 0, request.Length);

                // Nhận phản hồi (Danh sách ghế: "A1,B2...")
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    bookedSeats = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
                client.Close();
            }
            catch
            {
                MessageBox.Show("Không kết nối được Server để lấy dữ liệu ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở Form chọn ghế và TRUYỀN DANH SÁCH GHẾ ĐÃ BÁN SANG
            FormChonGhe frm = new FormChonGhe(
                name, email, movie, cinema, seatCount, ip, port,
                bookedSeats, posterUrl
            );
            frm.ShowDialog();
        }
    }
}
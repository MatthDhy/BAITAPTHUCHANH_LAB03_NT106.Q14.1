using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Bai04
{
    public partial class FormChonGhe : BaseForm
    {
        // Biến lưu thông tin
        string _name, _phone, _movie, _cinema, _serverIP;
        int _port;
        int _ticketCount;

        // Danh sách ghế đã được đặt trước đó (từ Server gửi về)
        List<string> _alreadyBooked;

        // Danh sách ghế khách đang chọn hiện tại
        List<Button> selectedSeats = new List<Button>();

        public FormChonGhe(string name, string phone, string movie, string cinema, int count, string ip, int port, string bookedSeatsString)
        {
            InitializeComponent();

            // Lưu dữ liệu
            _name = name;
            _phone = phone;
            _movie = movie;
            _cinema = cinema;
            _ticketCount = count;
            _serverIP = ip;
            _port = port;

            // Xử lý chuỗi ghế đã đặt
            if (!string.IsNullOrEmpty(bookedSeatsString))
            {
                _alreadyBooked = new List<string>(bookedSeatsString.Split(','));
            }
            else
            {
                _alreadyBooked = new List<string>();
            }

            lblInfo.Text = $"Xin chào {name}, vui lòng chọn đúng {count} ghế.";

            InitSeats(); // Tạo ghế
        }

        void InitSeats()
        {
            pnlSeats.Controls.Clear();
            char[] rows = { 'A', 'B', 'C' };

            foreach (char row in rows)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Button btn = new Button();
                    string seatName = $"{row}{i}";
                    btn.Text = seatName;
                    btn.Width = 70;
                    btn.Height = 50;
                    btn.Margin = new Padding(5);
                    btn.FlatStyle = FlatStyle.Flat;

                    // --- KIỂM TRA: Nếu ghế đã có trong danh sách đã đặt ---
                    if (_alreadyBooked.Contains(seatName))
                    {
                        btn.BackColor = Color.Gray; // Xám
                        btn.Enabled = false;        // Không cho bấm
                        btn.Text = "X";             // Đánh dấu
                    }
                    else
                    {
                        btn.BackColor = Color.WhiteSmoke; // Trắng
                        btn.ForeColor = Color.Black;
                        btn.Click += Seat_Click;    // Chỉ ghế trống mới được bấm
                    }

                    pnlSeats.Controls.Add(btn);

                    if (i == 5) pnlSeats.SetFlowBreak(btn, true);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackColor == Color.Yellow) // Đang chọn -> Bỏ chọn
            {
                btn.BackColor = Color.WhiteSmoke;
                selectedSeats.Remove(btn);
            }
            else // Chưa chọn -> Chọn
            {
                if (selectedSeats.Count < _ticketCount)
                {
                    btn.BackColor = Color.Yellow;
                    selectedSeats.Add(btn);
                }
                else
                {
                    MessageBox.Show("Bạn đã chọn đủ số lượng ghế!", "Thông báo");
                }
            }
            UpdateTotal();
        }

        void UpdateTotal()
        {
            decimal total = selectedSeats.Count * 50000;
            lblTotal.Text = $"Tạm tính: {total:N0} VNĐ";
            btnConfirm.BackColor = (selectedSeats.Count == _ticketCount) ? Color.LimeGreen : Color.Crimson;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count < _ticketCount)
            {
                MessageBox.Show($"Vui lòng chọn đủ {_ticketCount} ghế!", "Chưa xong");
                return;
            }

            string seatList = string.Join(",", selectedSeats.Select(s => s.Text));
            decimal totalMoney = _ticketCount * 50000;

            // Tạo nội dung hiển thị đẹp cho khách
            string billInfoClient =
                "           ========== HÓA ĐƠN ĐẶT VÉ ==========\n\n" +
        $"🎬 Phim: {_movie}\n" +
        $"📍 Rạp: {_cinema}\n" +
        $"🕒 Thời gian đặt: {DateTime.Now:dd/MM/yyyy HH:mm}\n" +
        "--------------------------------------------------\n" +
        $"👤 Khách hàng: {_name}\n" +
        $"📞 Số điện thoại: {_phone}\n" +
        $"💺 Ghế đã chọn: [{seatList}]\n" +
        $"🎟️ Số lượng vé: {_ticketCount}\n" +
        "--------------------------------------------------\n" +
        $"💰 TỔNG THANH TOÁN: {totalMoney:N0} VNĐ\n\n" +
        "✅ Đặt vé thành công! Vui lòng đọc SĐT để thanh toán và nhận vé tại quầy.";

            // Gửi dữ liệu chuẩn về Server: BOOK | Danh sách ghế | Nội dung log
            string packetToSend = $"BOOK|{seatList}|Khách: {_name}, Phim: {_movie}, Ghế: {seatList}, Tiền: {totalMoney:N0}";

            try
            {
                TcpClient client = new TcpClient();
                client.Connect(_serverIP, _port);
                byte[] data = Encoding.UTF8.GetBytes(packetToSend);
                client.GetStream().Write(data, 0, data.Length);
                client.Close();

                MessageBox.Show(billInfoClient, "Hoàn tất");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi đơn: " + ex.Message);
            }
        }
    }
}
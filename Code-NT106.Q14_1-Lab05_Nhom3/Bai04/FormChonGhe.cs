using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;           // Thư viện mạng
using System.Net.Mail;      // Thư viện gửi mail chuẩn của C#
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Bai04
{
    public partial class FormChonGhe : BaseForm
    {
        string _name, _email, _movie, _cinema, _serverIP, _posterUrl;
        int _port;
        int _ticketCount;
        List<string> _alreadyBooked;
        List<Button> selectedSeats = new List<Button>();

        // Cập nhật Constructor nhận thêm posterUrl
        public FormChonGhe(string name, string email, string movie, string cinema, int count, string ip, int port, string bookedSeatsString, string posterUrl)
        {
            InitializeComponent();

            _name = name;
            _email = email; // Lưu email thay vì sdt
            _movie = movie;
            _cinema = cinema;
            _ticketCount = count;
            _serverIP = ip;
            _port = port;
            _posterUrl = posterUrl; // Lưu link ảnh

            if (!string.IsNullOrEmpty(bookedSeatsString))
                _alreadyBooked = new List<string>(bookedSeatsString.Split(','));
            else
                _alreadyBooked = new List<string>();

            lblInfo.Text = $"Xin chào {_name}, vui lòng chọn đúng {_ticketCount} ghế.";
            InitSeats();
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
                    btn.Width = 70; btn.Height = 50; btn.Margin = new Padding(5);
                    btn.FlatStyle = FlatStyle.Flat;

                    if (_alreadyBooked.Contains(seatName))
                    {
                        btn.BackColor = Color.Gray; btn.Enabled = false; btn.Text = "X";
                    }
                    else
                    {
                        btn.BackColor = Color.WhiteSmoke; btn.Click += Seat_Click;
                    }
                    pnlSeats.Controls.Add(btn);
                    if (i == 5) pnlSeats.SetFlowBreak(btn, true);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Yellow)
            {
                btn.BackColor = Color.WhiteSmoke; selectedSeats.Remove(btn);
            }
            else
            {
                if (selectedSeats.Count < _ticketCount)
                {
                    btn.BackColor = Color.Yellow; selectedSeats.Add(btn);
                }
                else MessageBox.Show("Đã chọn đủ số ghế!");
            }
            UpdateTotal();
        }

        void UpdateTotal()
        {
            decimal total = selectedSeats.Count * 50000;
            lblTotal.Text = $"Tạm tính: {total:N0} VNĐ";
            btnConfirm.BackColor = (selectedSeats.Count == _ticketCount) ? Color.LimeGreen : Color.Crimson;
        }

        // --- SỰ KIỆN THANH TOÁN & GỬI MAIL ---
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (selectedSeats.Count < _ticketCount)
            {
                MessageBox.Show($"Vui lòng chọn đủ {_ticketCount} ghế!", "Chưa xong");
                return;
            }

            string seatList = string.Join(", ", selectedSeats.Select(s => s.Text));
            decimal totalMoney = _ticketCount * 50000;

            // 1. Gửi thông tin về Server (Socket) - Giữ nguyên yêu cầu Lab 4
            string packetToSend = $"BOOK|{seatList}|Khách: {_name}, Mail: {_email}, Phim: {_movie}, Ghế: {seatList}, Tiền: {totalMoney:N0}";
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(_serverIP, _port);
                byte[] data = Encoding.UTF8.GetBytes(packetToSend);
                client.GetStream().Write(data, 0, data.Length);
                client.Close();
            }
            catch { MessageBox.Show("Không kết nối được Server (vẫn sẽ gửi mail cho khách)."); }

            // 2. Gửi Email xác nhận (Yêu cầu Lab 5)
            // Thay đổi con trỏ chuột để báo đang xử lý
            this.Cursor = Cursors.WaitCursor;
            btnConfirm.Enabled = false;
            btnConfirm.Text = "Đang gửi mail...";

            bool mailSent = SendEmailConfirmation(seatList, totalMoney);

            this.Cursor = Cursors.Default;

            if (mailSent)
            {
                MessageBox.Show($"Đặt vé thành công!\nMã vé đã được gửi tới email: {_email}", "Hoàn tất");
                this.Close();
            }
            else
            {
                MessageBox.Show("Đặt vé thành công nhưng gửi mail thất bại (Sai mật khẩu ứng dụng hoặc mạng yếu).", "Cảnh báo");
                btnConfirm.Enabled = true;
                btnConfirm.Text = "THANH TOÁN";
            }
        }

        // --- HÀM GỬI EMAIL (SMTP) ---
        private bool SendEmailConfirmation(string seats, decimal total)
        {
            try
            {
                // CẤU HÌNH GMAIL CỦA BẠN (SERVER GỬI)
                string fromEmail = "cpdhuy@gmail.com"; // <-- THAY EMAIL CỦA BẠN VÀO ĐÂY
                string password = "tgiq nkfa imvi hjlo";   // <-- THAY MẬT KHẨU ỨNG DỤNG VÀO ĐÂY (16 ký tự)

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromEmail);
                mail.To.Add(_email); // Gửi đến email khách hàng nhập
                mail.Subject = $"[UIT CINEMA] Xác nhận vé phim: {_movie}";
                mail.IsBodyHtml = true; // Cho phép dùng HTML để chèn ảnh

                // Tạo nội dung HTML đẹp mắt (Poster làm ảnh, Slogan, Thông tin)
                string htmlBody = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; padding: 20px;'>
                        <h2 style='color: #d35400; text-align: center;'>XÁC NHẬN ĐẶT VÉ THÀNH CÔNG</h2>
                        <p>Xin chào <b>{_name}</b>,</p>
                        <p>Cảm ơn bạn đã lựa chọn UIT Cinema. Dưới đây là thông tin vé của bạn:</p>
                        
                        <table style='width: 100%; border-collapse: collapse;'>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd;'><b>Phim:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd; color: #2980b9;'>{_movie}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd;'><b>Rạp:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd;'>{_cinema}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd;'><b>Ghế:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd; font-size: 18px; font-weight: bold;'>{seats}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd;'><b>Tổng tiền:</b></td>
                                <td style='padding: 10px; border-bottom: 1px solid #ddd; color: red;'>{total:N0} VNĐ</td>
                            </tr>
                        </table>

                        <br/>
                        <div style='text-align: center;'>
                            <img src='{_posterUrl}' alt='Poster Phim' style='max-width: 200px; border-radius: 10px; box-shadow: 0 4px 8px rgba(0,0,0,0.2);' />
                            <p><i>""Chúc bạn có những giây phút xem phim tuyệt vời!""</i></p>
                        </div>
                        
                        <hr/>
                        <p style='font-size: 12px; color: gray; text-align: center;'>Đây là email tự động, vui lòng không trả lời.</p>
                    </div>
                ";

                mail.Body = htmlBody;

                // Cấu hình SMTP Client (Gmail)
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(fromEmail, password);

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail: " + ex.Message);
                return false;
            }
        }
    }
}
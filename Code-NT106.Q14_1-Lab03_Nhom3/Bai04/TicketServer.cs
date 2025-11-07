using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Bai04
{
    internal class TicketServer
    {
        private static List<Seat> seats = new List<Seat>();
        private static List<TcpClient> clients = new List<TcpClient>();
        private static readonly object _lock = new object();

        private static void LoadSeatsFromFile(string filePath)
        {
            seats.Clear();
            Debug.WriteLine("[Server] Đang tải dữ liệu 6 ghế mặc định (A1-B3)...");

            // Hàng A
            seats.Add(new Seat { SeatId = "A1", IsBooked = false });
            seats.Add(new Seat { SeatId = "A2", IsBooked = false });
            seats.Add(new Seat { SeatId = "A3", IsBooked = true }); // Ghế A3 được đặt trước

            // Hàng B
            seats.Add(new Seat { SeatId = "B1", IsBooked = false });
            seats.Add(new Seat { SeatId = "B2", IsBooked = false });
            seats.Add(new Seat { SeatId = "B3", IsBooked = false });

            Debug.WriteLine($"[Server] Đã tải {seats.Count} ghế.");
        }

        public void StartServer()
        {
            try
            {
                LoadSeatsFromFile("seats.txt");

                TcpListener listener = new TcpListener(IPAddress.Any, 8888);
                listener.Start();
                Debug.WriteLine("[Server] Đã khởi động, đang lắng nghe tại cổng 8888...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    clients.Add(client);
                    Debug.WriteLine("[Server] Một Client vừa kết nối.");

                    Task.Run(() => HandleClient(client));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Server] Lỗi: {ex.Message}");
            }
        }

        private static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                    Debug.WriteLine($"[Server] Nhận: {message}");

                    string[] parts = message.Split(':');
                    string command = parts[0];
                    string response = "";

                    if (command == "GET_SEATS")
                    {
                        response = "SEAT_LIST:" + string.Join(";", seats.Select(s => $"{s.SeatId},{s.IsBooked}"));
                        SendMessage(client, response);
                    }
                    else if (command == "BOOK_SEAT")
                    {
                        string seatIdToBook = parts[1];
                        lock (_lock)
                        {
                            Seat seat = seats.FirstOrDefault(s => s.SeatId == seatIdToBook);
                            if (seat != null && !seat.IsBooked)
                            {
                                seat.IsBooked = true;
                                response = "BOOK_SUCCESS:" + seatIdToBook;
                                SendMessage(client, response);
                                BroadcastMessage($"SEAT_UPDATED:{seatIdToBook}", client);
                            }
                            else
                            {
                                response = "BOOK_FAIL:" + seatIdToBook;
                                SendMessage(client, response);
                            }
                        }
                    }
                    else if (command == "RESET_SEATS")
                    {
                        lock (_lock)
                        {
                            foreach (Seat seat in seats)
                            {
                                seat.IsBooked = false;
                            }
                            Debug.WriteLine("[Server] Đã reset tất cả các vé.");

                            response = "SEAT_LIST:" + string.Join(";", seats.Select(s => $"{s.SeatId},{s.IsBooked}"));

                            BroadcastMessage(response, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Server] Client ngắt kết nối: {ex.Message}");
            }
            finally
            {
                clients.Remove(client);
                client.Close();
            }
        }

        private static void SendMessage(TcpClient client, string message)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.GetStream().Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Server] Lỗi gửi tin: {ex.Message}");
            }
        }

        private static void BroadcastMessage(string message, TcpClient excludeClient)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            foreach (TcpClient client in clients.ToList())
            {
                if (client != excludeClient)
                {
                    try
                    {
                        client.GetStream().Write(data, 0, data.Length);
                    }
                    catch (Exception)
                    {
                        clients.Remove(client);
                    }
                }
            }
            Debug.WriteLine($"[Server] Broadcasted: {message}");
        }
    }
    public class Seat
    {
        public string SeatId { get; set; }
        public bool IsBooked { get; set; }
    }
}

using System;

namespace Bai06
{
    // Lớp này không cần thư viện JSON vì nó chỉ là nơi lưu trữ dữ liệu (POCO)
    public class ChatMessage
    {
        // Loại tin nhắn: "login", "message", "private", "file", "userlist", "disconnect"
        public string Type { get; set; }

        // Người gửi
        public string From { get; set; }

        // Người nhận (dùng cho tin nhắn riêng hoặc file riêng)
        // Sẽ là null nếu gửi cho tất cả (broadcast)
        public string To { get; set; }

        // Nội dung tin nhắn (cho Type "message", "private")
        // Hoặc JSON của List<string> (cho Type "userlist")
        public string Text { get; set; }

        // --- Dùng cho gửi file (Type "file") ---

        // Tên file gốc (ví dụ: "image.png" hoặc "report.txt")
        public string FileName { get; set; }

        // Nội dung file đã được mã hóa sang Base64
        public string FileBase64 { get; set; }
    }
}
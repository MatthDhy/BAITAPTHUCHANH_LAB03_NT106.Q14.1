using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07.Models
{
    public class UserSignup
    {
        // Thông tin tài khoản
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }
        public string birthday { get; set; } // YYYY-MM-DD
        public int sex { get; set; }         // Sửa thành int (0 hoặc 1)
        public string language { get; set; }
    }
}

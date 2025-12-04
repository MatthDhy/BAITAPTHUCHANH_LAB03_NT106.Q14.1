using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07.Models
{
    public class User
    {
        public string id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        // Thêm các trường khác nếu API trả về
    }
}

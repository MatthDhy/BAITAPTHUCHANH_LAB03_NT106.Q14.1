using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07.Models
{
    public class Dish
    {
        public int id { get; set; }
        public string ten_mon_an { get; set; }
        public double gia { get; set; }
        public string dia_chi { get; set; }
        public string hinh_anh { get; set; } // URL ảnh
        public string mo_ta { get; set; }
        public string nguoi_dong_gop { get; set; }
    }
}

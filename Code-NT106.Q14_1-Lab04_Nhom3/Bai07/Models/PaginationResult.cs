using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07.Models
{
    public class Pagination
    {
        public int current { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
    public class PaginationResult<T>
    {
        public List<T> data { get; set; } // Danh sách dữ liệu
        public Pagination pagination { get; set; } // Thông tin phân trang
    }
}

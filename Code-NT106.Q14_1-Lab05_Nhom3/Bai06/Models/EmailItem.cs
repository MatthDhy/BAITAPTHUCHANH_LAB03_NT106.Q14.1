using System;

namespace Bai06.Models
{
    public class EmailItem
    {
        public int Index { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ItemCard
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ApproximateAddress { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int NumberOfBeds { get; set; }
        public int NumberOfBathrooms { get; set; }
        public decimal? MinPrice { get; set; }
        public string ThumbnailPath { get; set; }
        public string Status { get; set; } // "Active", "Occupied", "Draft"
        public string HostName { get; set; } // tùy chọn
    }
}

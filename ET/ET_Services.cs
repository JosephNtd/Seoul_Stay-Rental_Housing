using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Services
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; } // Hiển thị trên Grid
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long? Duration { get; set; }
        public string Description { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public long DailyCap { get; set; }
        public long BookingCap { get; set; }
        public string Capacity
        {
            get => $"{DailyCap}/ {BookingCap}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ItemAvailability
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public DateTime Date { get; set; }
        public bool IsAvailable { get; set; }
    }
}

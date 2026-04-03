using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ItemPrices
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long ItemID { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public long CancellationPolicyID { get; set; }
        public ET_ItemPrices()
        {
        }
        public ET_ItemPrices(long iD, Guid gUID, long itemID, DateTime date, decimal price, long cancellationPolicyID)
        {
            ID = iD;
            GUID = gUID;
            ItemID = itemID;
            Date = date;
            Price = price;
            CancellationPolicyID = cancellationPolicyID;
        }
    }
}

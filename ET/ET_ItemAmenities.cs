using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ItemAmenities
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long ItemID { get; set; }
        public long AmenityID { get; set; }
        public ET_ItemAmenities()
        {
        }

        public ET_ItemAmenities(long iD, Guid gUID, long itemID, long amenityID)
        {
            ID = iD;
            GUID = gUID;
            ItemID = itemID;
            AmenityID = amenityID;
        }
    }
}

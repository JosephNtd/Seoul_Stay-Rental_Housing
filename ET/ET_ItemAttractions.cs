using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ItemAttractions
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long ItemID { get; set; }
        public long AttractionID { get; set; }
        public decimal? Distance { get; set; }
        public long? DurationOnFoot { get; set; }
        public long? DurationByCar { get; set; }
        public ET_ItemAttractions()
        {
        }
        public ET_ItemAttractions(long iD, Guid gUID, long itemID, long attractionID, decimal? distance, long? durationOnFoot, long? durationByCar)
        {
            ID = iD;
            GUID = gUID;
            ItemID = itemID;
            AttractionID = attractionID;
            Distance = distance;
            DurationOnFoot = durationOnFoot;
            DurationByCar = durationByCar;
        }
    }
}

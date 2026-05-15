using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Attractions
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long AreaID { get; set; }
        public string AttractionName { get; set; }
        public string Address { get; set; }
    
        public ET_Attractions() { }

        public ET_Attractions(long iD, Guid gUID, long areaID, string name, string address)
        {
            ID = iD;
            GUID = gUID;
            AreaID = areaID;
            AttractionName = name;
            Address = address;
        }
        public ET_Attractions(long iD, long areaID, string name, string address)
        {
            ID = iD;
            AreaID = areaID;
            AttractionName = name;
            Address = address;
        }
        public ET_Attractions(long areaID, string name, string address)
        {
            AreaID = areaID;
            AttractionName = name;
            Address = address;
        }
    }
}

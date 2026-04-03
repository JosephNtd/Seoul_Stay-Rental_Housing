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
        public string Name { get; set; }
        public string Address { get; set; }
    
        public ET_Attractions() { }

        public ET_Attractions(long iD, Guid gUID, long areaID, string name, string address)
        {
            ID = iD;
            GUID = gUID;
            AreaID = areaID;
            Name = name;
            Address = address;
        }
    }
}

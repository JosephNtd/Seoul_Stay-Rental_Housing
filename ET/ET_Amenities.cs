using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Amenities
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public ET_Amenities() { }
        public ET_Amenities(long iD, Guid gUID, string name, string iconName)
        {
            ID = iD;
            GUID = gUID;
            Name = name;
            IconName = iconName;
        }
    }
}

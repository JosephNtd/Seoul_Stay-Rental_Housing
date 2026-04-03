using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Areas
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string Name { get; set; }

        public ET_Areas() { }
        public ET_Areas(long iD, Guid gUID, string name)
        {
            ID = iD;
            GUID = gUID;
            Name = name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_UserTypes
    {
        public long ID { get; set; }
        public System.Guid GUID { get; set; }
        public string Name { get; set; }     // "employee" | "user"

        public ET_UserTypes() { }

        public ET_UserTypes(long id, System.Guid guid, string name)
        {
            ID = id;
            GUID = guid;
            Name = name;
        }
    }
}

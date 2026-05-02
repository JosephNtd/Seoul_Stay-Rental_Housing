using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_CancellationPolicies
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public decimal PlatformCommissionRate { get; set; }
        public ET_CancellationPolicies()
        {
        }

        public ET_CancellationPolicies(long iD, Guid gUID, string name, decimal platformCommissionRate)
        {
            ID = iD;
            GUID = gUID;
            Name = name;
            PlatformCommissionRate = platformCommissionRate;
        }
    }
}

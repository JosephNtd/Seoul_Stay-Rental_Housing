using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_CancellationRefundFees
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long CancellationPolicyID { get; set; }
        public int DaysLeft { get; set; }
        public decimal PenaltyPercentage { get; set; }

        public ET_CancellationRefundFees()
        {
        }

        public ET_CancellationRefundFees(long iD, Guid gUID, long cancellationPolicyID, int daysLeft, decimal penaltyPercentage)
        {
            ID = iD;
            GUID = gUID;
            CancellationPolicyID = cancellationPolicyID;
            DaysLeft = daysLeft;
            PenaltyPercentage = penaltyPercentage;
        }
    }
}

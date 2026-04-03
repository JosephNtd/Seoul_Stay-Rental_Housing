using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Coupons
    {
        

        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal MaximimDiscountAmount { get; set; }
        public ET_Coupons() {}
        public ET_Coupons(long iD, Guid gUID, string couponCode, decimal discountPercent, decimal maximimDiscountAmount)
        {
            ID = iD;
            GUID = gUID;
            CouponCode = couponCode;
            DiscountPercent = discountPercent;
            MaximimDiscountAmount = maximimDiscountAmount;
        }
    }
}

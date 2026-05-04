using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Host: ET_Users
    {
        public string BusinessLicense { get; set; }
        public string TaxCode { get; set; }
        public bool IsVerified { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public decimal? Rating { get; set; }
        public int TotalReviews { get; set; }
        public DateTime JoinedAsHostDate { get; set; }
        public ET_Host() : base() { }

        // Constructor đầy đủ
        public ET_Host(long id, Guid guid, string username, string password, string fullName,
                       string email, byte gender, DateTime birthDate, bool isAdmin,
                       string businessLicense, string taxCode, bool isVerified,
                       DateTime? verifiedDate, decimal? rating, int totalReviews,
                       DateTime joinedAsHostDate)
            : base(id, guid, username, password, fullName, email, gender, birthDate, isAdmin)
        {
            BusinessLicense = businessLicense;
            TaxCode = taxCode;
            IsVerified = isVerified;
            VerifiedDate = verifiedDate;
            Rating = rating;
            TotalReviews = totalReviews;
            JoinedAsHostDate = joinedAsHostDate;
        }
    }
}

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
        public ET_Host(
            long iD, Guid gUID, string username, string password, string fullName,
            string email, string phoneNumber, byte gender, DateTime? birthDate,
            string country, string profilePicture,
            string businessLicense, string taxCode, bool isVerified,
            DateTime? verifiedDate, decimal? rating, int totalReviews,
            DateTime joinedAsHostDate)
            : base(iD, gUID, username, password, fullName, email, phoneNumber, gender, birthDate, country, profilePicture)
        {
            BusinessLicense = businessLicense;
            TaxCode = taxCode;
            IsVerified = isVerified;
            VerifiedDate = verifiedDate;
            Rating = rating;
            TotalReviews = totalReviews;
            JoinedAsHostDate = joinedAsHostDate;
        }
        public ET_Host(
            long iD, string fullName,
            string email, string phoneNumber, byte gender, DateTime? birthDate,
            string country,
            string businessLicense, string taxCode)
            : base(iD, fullName, email, phoneNumber, gender, birthDate, country)
        {
            BusinessLicense = businessLicense;
            TaxCode = taxCode;
        }
    }
}

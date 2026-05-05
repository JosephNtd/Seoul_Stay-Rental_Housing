using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Guest: ET_Users
    {
        public int LoyaltyPoints { get; set; }
        public string PreferredLanguage { get; set; }
        public string NationalID { get; set; }
        public bool NationalIDVerified { get; set; }

        // Kế thừa constructor
        public ET_Guest() : base() { }

        public ET_Guest(
                        long iD, Guid gUID, string username, string password, string fullName,
                        string email, string phoneNumber, byte gender, DateTime? birthDate,
                        string country, string profilePicture,
                        int loyaltyPoints, string preferredLanguage, string nationalID,
                        bool nationalIDVerified)
            : base(iD, gUID, username, password, fullName, email, phoneNumber, gender, birthDate, country, profilePicture)
        {
            LoyaltyPoints = loyaltyPoints;
            PreferredLanguage = preferredLanguage;
            NationalID = nationalID;
            NationalIDVerified = nationalIDVerified;
        }
    }
}

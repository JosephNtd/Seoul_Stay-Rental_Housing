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

        public ET_Guest(long id, Guid guid, string username, string password, string fullName,
                        string email, byte gender, DateTime birthDate, bool isAdmin,
                        int loyaltyPoints, string preferredLanguage, string nationalID,
                        bool nationalIDVerified)
            : base(id, guid, username, password, fullName, email, gender, birthDate, isAdmin)
        {
            LoyaltyPoints = loyaltyPoints;
            PreferredLanguage = preferredLanguage;
            NationalID = nationalID;
            NationalIDVerified = nationalIDVerified;
        }
    }
}

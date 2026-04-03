using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_Users
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long UserTypeID { get; set; }   // 1 = employee, 2 = user
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }   // false = Nam, true = Nữ
        public DateTime BirthDate { get; set; }
        public int FamilyCount { get; set; }

        // Navigation (không map DB, dùng để hiển thị trên UI)
        public ET_UserTypes ET_UserType { get; set; }

        // Computed helper
        public bool IsEmployee => UserTypeID == 1;
        public bool IsUser => UserTypeID == 2;

        public ET_Users() { }

        public ET_Users(long id, Guid guid, long userTypeID, string username,
                    string password, string fullName, bool gender,
                    DateTime birthDate, int familyCount)
        {
            ID = id;
            GUID = guid;
            UserTypeID = userTypeID;
            Username = username;
            Password = password;
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
            FamilyCount = familyCount;
        }
    }
}

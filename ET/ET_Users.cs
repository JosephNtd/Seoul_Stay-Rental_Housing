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
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte Gender { get; set; }   // Gender: 0=Unknown  1=Male  2=Female  3=Other
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }

        public bool IsEmployee => IsAdmin;
        public bool IsUser => !IsAdmin;

        public ET_Users() { }

        public ET_Users(long id, Guid guid, string username,
                    string password, string fullName, string email, byte gender,
                    DateTime birthDate, bool isAdmin)
        {
            ID = id;
            GUID = guid;
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Gender = gender;
            BirthDate = birthDate;
            IsAdmin = isAdmin;
        }
    }
}

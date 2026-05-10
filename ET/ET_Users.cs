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

        public Guid GUID { get; set; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        /// <summary>
        /// 0: Unknown, 1: Male, 2: Female, 3: Other
        /// </summary>
        public byte Gender { get; set; } = 0;

        public DateTime? BirthDate { get; set; }

        public string Country { get; set; }

        public string ProfilePicture { get; set; }

        public bool IsAdmin { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public ET_Users() { }

        public ET_Users(
            long iD, Guid gUID, string username, string password, string fullName, 
            string email, string phoneNumber, byte gender, DateTime? birthDate, 
            string country, string profilePicture)
        {
            ID = iD;
            GUID = gUID;
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            BirthDate = birthDate;
            Country = country;
            ProfilePicture = profilePicture;
        }
        public ET_Users(
            long iD, string fullName, 
            string email, string phoneNumber, byte gender, DateTime? birthDate, string country)
        {
            ID = iD;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
            BirthDate = birthDate;
            Country = country;
        }

    }
}

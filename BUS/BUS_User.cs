using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ET;

namespace BUS
{
    public class BUS_User
    {
        private readonly DAL_User _dal = new DAL_User();
        public ET_Users Login(string username, string password, bool employeeOnly = false)
        {
            //if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            //    return null;

            //return employeeOnly ? _dal.LoginEmployee(username.Trim(), password): _dal.Login(username.Trim(), password);

            var u = employeeOnly? _dal.LoginEmployee(username.Trim(), password): _dal.Login(username.Trim(), password);

            if (u == null) return null;

            return new ET_Users
            {
                ID = u.ID,
                Username = u.Username,
                FullName = u.FullName,
                Gender = u.Gender,
                BirthDate = u.BirthDate,
                FamilyCount = u.FamilyCount
            };
        }

        public bool Register(string username, string password, string fullName,
                             bool gender, DateTime birthDate, int familyCount)
        {
            var user = new User()
            {
                Username = username.Trim(),
                Password = password,
                FullName = fullName.Trim(),
                Gender = gender,
                BirthDate = birthDate,
                FamilyCount = familyCount,
            };

            return _dal.Register(user);
        }

        public bool CheckUsername(string username)
        {
            return _dal.CheckUsername(username);
        }

        public User GetByID(long id) => _dal.GetById(id);
    }
}

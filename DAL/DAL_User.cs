using System;
using Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_User
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public User Login(string username, string password)
        {
            //string hash = Helper_Security.Hash(password);
            return db.Users
                     .FirstOrDefault(x => x.Username == username
                                       && x.Password == password);
        }
        public User LoginEmployee(string username, string password)
        {
            //string hash = Helper_Security.Hash(password);
            return db.Users
                     .FirstOrDefault(x => x.Username == username
                                       && x.Password == password
                                       && x.UserTypeID == 1); 
        }
        public bool CheckUsername(string username)
        {
            return db.Users.Any(x => x.Username == username);
        }
        public bool Register(User newUser)
        {
            try
            {
                newUser.GUID = Guid.NewGuid();
                newUser.UserTypeID = 2;

                db.Users.InsertOnSubmit(newUser);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetById(long id)
        {
            return db.Users.FirstOrDefault(u => u.ID == id);
        }
    }

}

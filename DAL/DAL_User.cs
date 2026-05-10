using DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_User
    {
        //DataClasses1DataContext db = new DataClasses1DataContext();
        Seoul_StayDataContext db = new Seoul_StayDataContext();
        public User Login(string username, string password)
        {
            //string hash = Helper_Security.Hash(password);
            return db.Users
                     .FirstOrDefault(x => x.Username == username
                                       && x.Password == password
                                       /*&& x.IsAdmin*/);
        }
        public User LoginEmployee(string username, string password)
        {
            //string hash = Helper_Security.Hash(password);
            return db.Users
                     .FirstOrDefault(x => x.Username == username
                                       && x.Password == password);
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
                newUser.IsAdmin = false;
                newUser.CreatedDate = DateTime.Now;
                newUser.IsActive = true;

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

        // Thêm vào DAL_User.cs
        public List<DTO_UserDisplay> GetAllUsersDisplay()
        {
            using (var context = new Seoul_StayDataContext())
            {
                var data = (from u in context.Users
                            join h in context.Hosts on u.ID equals h.UserID into hostJoin
                            from h in hostJoin.DefaultIfEmpty()

                            join g in context.Guests on u.ID equals g.UserID into guestJoin
                            from g in guestJoin.DefaultIfEmpty()

                            select new
                            {
                                u.ID,
                                u.FullName,
                                u.Email,
                                u.IsActive,
                                u.IsAdmin,
                                u.CreatedDate,
                                Host = h
                            }).ToList();

                return data.Select(u => new DTO_UserDisplay
                {
                    UserID = u.ID,
                    FullName = u.FullName,
                    Email = u.Email,
                    Status = u.IsActive ? "Active" : "Locked    ",
                    Role = u.IsAdmin
                            ? "Administrator"
                            : u.Host != null
                                ? "Host"
                                : "Guest",

                    LastActive = u.CreatedDate.ToString("MMMM dd, yyyy")
                }).ToList();
            }
        }
    }

}

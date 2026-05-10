using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Host
    {
        public ET_Host GetHostProfile(long userId)
        {
            using (var db = new Seoul_StayDataContext())
            {
                var query = from h in db.Hosts
                            join u in db.Users on h.UserID equals u.ID
                            where h.UserID == userId
                            select new ET_Host
                            {
                                // Các thuộc tính từ Users
                                ID = u.ID,
                                GUID = u.GUID,
                                Username = u.Username,
                                Password = u.Password,
                                FullName = u.FullName,
                                Email = u.Email,
                                PhoneNumber = u.PhoneNumber,
                                Gender = u.Gender,
                                BirthDate = u.BirthDate,
                                Country = u.Country,
                                ProfilePicture = u.ProfilePicture,

                                // Các thuộc tính từ Hosts
                                BusinessLicense = h.BusinessLicense,
                                TaxCode = h.TaxCode,
                                IsVerified = h.IsVerified,
                                Rating = h.Rating,
                                TotalReviews = h.TotalReviews,
                                JoinedAsHostDate = h.JoinedAsHostDate
                            };
                return query.FirstOrDefault();
            }
        }

        public bool Update(ET_Host editData)
        {
            using(var db = new Seoul_StayDataContext())
            {
                var userInfo = db.Users.FirstOrDefault(x => x.ID == editData.ID);
                if (userInfo == null) return false;

                var hostInfo = db.Hosts.FirstOrDefault(x => x.UserID == editData.ID);
                if (hostInfo == null) return false;

                // Update user infomation
                //userInfo.Username = editData.Username;
                //userInfo.Password = editData.Password;
                userInfo.FullName = editData.FullName;
                userInfo.Email = editData.Email;
                userInfo.PhoneNumber = editData.PhoneNumber;
                userInfo.Gender = editData.Gender;
                userInfo.BirthDate = editData.BirthDate;
                userInfo.Country = editData.Country;
                //userInfo.ProfilePicture = editData.ProfilePicture;

                // Update host infomation
                hostInfo.BusinessLicense = editData.BusinessLicense;
                hostInfo.TaxCode = editData.TaxCode;

                db.SubmitChanges();

                return true;
            }
        }
    }
}

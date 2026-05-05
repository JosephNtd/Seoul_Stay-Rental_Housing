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
        public List<ET_HostBankAccount> GetBankAccounts(long hostUserId)
        {
            using (var db = new Seoul_StayDataContext())
            {
                return db.HostBankAccounts
                         .Where(a => a.HostUserID == hostUserId && a.IsActive)
                         .Select(a => new ET_HostBankAccount
                         {
                             ID = a.ID,
                             GUID = a.GUID,
                             HostUserID = a.HostUserID,
                             BankName = a.BankName,
                             AccountNumber = a.AccountNumber,
                             AccountHolder = a.AccountHolder,
                             IsPrimary = a.IsPrimary,
                             IsVerified = a.IsVerified,
                             CreatedDate = a.CreatedDate,
                             IsActive = a.IsActive
                         })
                         .ToList();
            }
        }

        public bool SaveBankAccount(ET_HostBankAccount account)
        {
            using (var db = new Seoul_StayDataContext())
            {
                HostBankAccount entity;
                if (account.ID == 0) // Thêm mới
                {
                    entity = new HostBankAccount
                    {
                        GUID = Guid.NewGuid(),
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };
                    db.HostBankAccounts.InsertOnSubmit(entity);
                }
                else // Cập nhật
                {
                    entity = db.HostBankAccounts.FirstOrDefault(a => a.ID == account.ID);
                    if (entity == null) return false;
                }

                // Gán thuộc tính
                entity.HostUserID = account.HostUserID;
                entity.BankName = account.BankName;
                entity.AccountNumber = account.AccountNumber;
                entity.AccountHolder = account.AccountHolder;
                entity.IsPrimary = account.IsPrimary;
                entity.IsVerified = account.IsVerified; // thường do admin xác minh, nhưng vẫn cho gán

                // Nếu đặt là primary, bỏ primary các tài khoản khác của host
                if (entity.IsPrimary)
                {
                    var others = db.HostBankAccounts.Where(a => a.HostUserID == entity.HostUserID && a.ID != entity.ID);
                    foreach (var other in others) other.IsPrimary = false;
                }

                db.SubmitChanges();
                account.ID = entity.ID; // trả lại ID cho đối tượng ET
                return true;
            }
        }

        public bool DeleteBankAccount(long accountId)
        {
            using (var db = new Seoul_StayDataContext())
            {
                var acc = db.HostBankAccounts.FirstOrDefault(a => a.ID == accountId);
                if (acc != null)
                {
                    db.HostBankAccounts.DeleteOnSubmit(acc);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}

using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HostBankAccount
    {

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

        public bool Insert(ET_HostBankAccount data)
        {
            using (var db = new Seoul_StayDataContext())
            {
                var account = new HostBankAccount
                {
                    GUID = Guid.NewGuid(),
                    HostUserID = data.HostUserID,
                    BankName = data.BankName,
                    AccountNumber = data.AccountNumber,
                    AccountHolder = data.AccountHolder,
                    IsPrimary = data.IsPrimary,
                    IsVerified = data.IsVerified,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };
                db.HostBankAccounts.InsertOnSubmit(account);
                db.SubmitChanges();
                return true;
            }
        }

        public bool Update(ET_HostBankAccount data)
        {
            using (var db = new Seoul_StayDataContext())
            {
                var acc = db.HostBankAccounts.FirstOrDefault(a => a.ID == data.ID);
                if (acc == null) return false;
                acc.BankName = data.BankName;
                acc.AccountNumber = data.AccountNumber;
                acc.AccountHolder = data.AccountHolder;
                acc.IsPrimary = data.IsPrimary;
                // nếu set primary, các tài khoản khác của host này thành false
                if (acc.IsPrimary)
                {
                    var others = db.HostBankAccounts.Where(a => a.HostUserID == acc.HostUserID && a.ID != acc.ID);
                    foreach (var o in others) o.IsPrimary = false;
                }
                db.SubmitChanges();
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

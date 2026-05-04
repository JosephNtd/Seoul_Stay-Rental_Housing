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
        Seoul_StayDataContext db = new Seoul_StayDataContext();

        public List<HostBankAccount> GetByHost(long hostUserId)
        {
            return db.HostBankAccounts.Where(a => a.HostUserID == hostUserId && a.IsActive).ToList();
        }

        public bool Insert(ET_HostBankAccount data)
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

        public bool Update(ET_HostBankAccount data)
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

        public bool Delete(long id)
        {
            var acc = db.HostBankAccounts.FirstOrDefault(a => a.ID == id);
            if (acc != null)
            {
                acc.IsActive = false; // soft delete
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}

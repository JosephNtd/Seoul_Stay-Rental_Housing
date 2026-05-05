using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Host
    {
        private readonly DAL_Host _dal = new DAL_Host();

        public ET_Host GetHostProfile(long userId) => _dal.GetHostProfile(userId);
        public List<ET_HostBankAccount> GetBankAccounts(long hostUserId) => _dal.GetBankAccounts(hostUserId);
        public bool SaveBankAccount(ET_HostBankAccount account) => _dal.SaveBankAccount(account);
        public bool DeleteBankAccount(long accountId) => _dal.DeleteBankAccount(accountId);
    }
}

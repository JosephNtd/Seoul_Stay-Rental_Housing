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
        private readonly DAL_Host _host = new DAL_Host();
        private readonly DAL_HostBankAccount _bank = new DAL_HostBankAccount();

        public ET_Host GetHostProfile(long userId) => _host.GetHostProfile(userId);
        public bool UpdateHostProfile(ET_Host info) => _host.Update(info);
        public List<ET_HostBankAccount> GetBankAccounts(long hostUserId) => _bank.GetBankAccounts(hostUserId);
        public bool SaveBankAccount(ET_HostBankAccount account)
        {
            if (account.ID > 0)
                return _bank.Update(account);

            return _bank.Insert(account);
        }
        public bool DeleteBankAccount(long accountId) => _bank.DeleteBankAccount(accountId);
    }
}

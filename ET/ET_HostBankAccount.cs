using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_HostBankAccount
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long HostUserID { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAddCard { get; set; }
        public string PrimaryVisible =>
            IsPrimary ? "inline-block" : "none";

        public string VerifiedVisible =>
            IsVerified ? "inline-block" : "none";
        public string NormalCardDisplay =>
            IsAddCard ? "none" : "block";

        public string AddCardDisplay =>
            IsAddCard ? "flex" : "none";
        public string MaskedAccountNumber
        {
            get
            {
                if (string.IsNullOrEmpty(AccountNumber))
                    return "****";

                if (AccountNumber.Length <= 4)
                    return AccountNumber;

                return "•••• •••• " +
                       AccountNumber.Substring(AccountNumber.Length - 4);
            }
        }
        public ET_HostBankAccount() { }
    }
}

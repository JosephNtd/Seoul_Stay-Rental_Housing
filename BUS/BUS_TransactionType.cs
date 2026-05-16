using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_TransactionType
    {
        private DAL_TransactionType _dal = new DAL_TransactionType();

        public List<ET_TransactionTypes> GetData() => _dal.GetData();

        public bool IsNameExists(string name, long idToIgnore = 0) => _dal.IsNameExists(name, idToIgnore);

        public bool Insert(ET_TransactionTypes et) => _dal.Insert(et);

        public bool Update(ET_TransactionTypes et) => _dal.Update(et);

        public bool Delete(long id) => _dal.Delete(id);
    }
}

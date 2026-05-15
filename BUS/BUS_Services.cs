using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Services
    {
        private DAL_Services _dal = new DAL_Services();

        public List<ET_Services> GetAll() => _dal.GetAll();
        public bool IsNameExists(string name, long idToIgnore = 0) => _dal.IsNameExists(name, idToIgnore);
        public bool Insert(ET_Services et) => _dal.Insert(et);
        public bool Update(ET_Services et) => _dal.Update(et);
        public bool Delete(long id) => _dal.Delete(id);
    }
}

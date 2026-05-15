using DAL;
using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Attraction
    {
        DAL_Attraction _dal = new DAL_Attraction();
        public List<DTO_Attraction_Distance> GetData(long? itemId = null)
        {
            return _dal.GetData(itemId);
        }
        public List<ET_Attractions> GetAllData()
        {
            return _dal.GetAllData();
        }
        public List<DTO_AttractionDisplay> GetAllWithAreaName()
        {
            return _dal.GetAllWithAreaName();
        }
        public bool Insert(ET_Attractions et)
        {
            return _dal.Insert(et);
        }
        public bool IsNameExists(string name, long idToIgnore = 0)
        {
            return _dal.IsNameExists(name, idToIgnore);
        }
        public bool Update(ET_Attractions et)
        {
            return _dal.Update(et);
        }

        public bool Delete(long id)
        {
            return _dal.Delete(id);
        }
    }
}

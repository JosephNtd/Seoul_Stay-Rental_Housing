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
    public class BUS_Amenity
    {
        private readonly DAL_Amenity _dal = new DAL_Amenity();

        public List<DTO_Amenities> GetData(long? itemId = null) => _dal.GetData(itemId);
        public List<ET_Amenities> GetAllData() => _dal.GetAllData();
        public bool IsNameExists(string name, long idToIgnore = 0) => _dal.IsNameExists(name, idToIgnore);

        public bool Insert(ET_Amenities et, string iconFileName) => _dal.Insert(et, iconFileName);

        public bool Update(ET_Amenities et, string iconFileName) => _dal.Update(et, iconFileName);

        public bool Delete(long id) => _dal.Delete(id);

    }
}

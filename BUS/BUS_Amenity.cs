using DAL;
using DTO;
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

        public List<DTO_Amenities> GetData(long? itemId = null)
        {
            return _dal.GetData(itemId);
        }
        
    }
}

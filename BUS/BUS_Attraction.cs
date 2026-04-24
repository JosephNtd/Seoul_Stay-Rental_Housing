using DAL;
using DTO;
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
    }
}

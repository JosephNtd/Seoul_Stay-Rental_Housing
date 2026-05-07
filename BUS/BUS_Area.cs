using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Area
    {
        DAL_Area dal = new DAL_Area();

        public List<object> GetThongKe()
        {
            return dal.GetHotelCountByArea();
        }
        public List<ET_Areas> GetAreasName()
        {
            return dal.GetAreaName();
        }
    }
}

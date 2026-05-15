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
    public class BUS_Area
    {
        DAL_Area dal = new DAL_Area();

        public List<object> GetThongKe() => dal.GetHotelCountByArea();
        public List<ET_Areas> GetAreasName() => dal.GetAreaName();
        public List<DTO_AreaDisplay> GetData() => dal.GetData();
        public DTO_AreaOverview GetAreaOverview(long areaId) => dal.GetAreaOverview(areaId);
        public object GetItemsByArea(long areaId) => dal.GetItemsByArea(areaId);
        public object GetAttractionsByArea(long areaId) => dal.GetAttractionsByArea(areaId);

    }
}

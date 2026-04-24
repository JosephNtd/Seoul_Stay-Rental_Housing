using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Area
    {
        Seoul_StayDataContext db = new Seoul_StayDataContext();
        public List<object> GetHotelCountByArea()
        {
            var result = from a in db.Areas
                         join i in db.Items on a.ID equals i.AreaID into g
                         from x in g.DefaultIfEmpty()
                         group x by a.Name into grp
                         select new
                         {
                             AreaName = grp.Key,
                             HotelCount = grp.Count(i => i != null)
                         };

            return result.ToList<object>();
        }
    }
}

using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Area
    {
        
        public List<object> GetHotelCountByArea()
        {
            using(Seoul_StayDataContext db = new Seoul_StayDataContext())
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

        public List<ET_Areas> GetAreaName()
        {
            using (Seoul_StayDataContext db = new Seoul_StayDataContext())
            {
                var data = from t in db.Areas
                           select new ET_Areas
                           {
                               ID = t.ID,
                               Name = t.Name
                           };
                return data.ToList();
            }
        }
    }
}

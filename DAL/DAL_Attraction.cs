using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Attraction
    {
        Seoul_StayDataContext db = new Seoul_StayDataContext();
        public List<DTO_Attraction_Distance> GetData(long? itemId = null)
        {
            var itemAttractions = itemId.HasValue
                ? db.ItemAttractions.Where(i => i.ItemID == itemId.Value)
                : db.ItemAttractions.Where(i => false);

            return (from a in db.Attractions
                    join b in db.Areas on a.AreaID equals b.ID
                    join i in itemAttractions on a.ID equals i.AttractionID into joined
                    from i in joined.DefaultIfEmpty()
                    select new DTO_Attraction_Distance
                    {
                        AttractionID = a.ID,
                        Attraction = a.Name,
                        Area = b.Name,
                        Distance = i == null ? (decimal?)null : i.Distance,
                        OnFoot = i == null ? (long?)null : i.DurationOnFoot,
                        ByCar = i == null ? (long?)null : i.DurationByCar,
                    }).ToList();
        }
    }
}

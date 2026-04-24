using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Amenity
    {
        Seoul_StayDataContext db = new Seoul_StayDataContext();
        public List<DTO_Amenities> GetData(long? itemId = null)
        {
            var selectedAmenityIds = itemId.HasValue
                ? db.ItemAmenities
                    .Where(ia => ia.ItemID == itemId.Value)
                    .Select(ia => ia.AmenityID)
                    .ToList()
                : new List<long>();

            return db.Amenities
                .Select(p => new DTO_Amenities
                {
                    ID = p.ID,
                    Name = p.Name,
                    IsSelected = selectedAmenityIds.Contains(p.ID)
                })
                .ToList();
        }
    }
}

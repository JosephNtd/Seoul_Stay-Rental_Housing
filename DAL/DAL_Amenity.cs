using DTO;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Amenity
    {
        public List<DTO_Amenities> GetData(long? itemId = null)
        {
            using (var db = new Seoul_StayDataContext())
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

        public List<ET_Amenities> GetAllData()
        {
            using (var db = new Seoul_StayDataContext())
            {
                return db.Amenities
                    .Select(a => new ET_Amenities
                    {
                        ID = a.ID,
                        GUID = a.GUID,
                        AmenitiesName = a.Name,
                        IconName = a.IconName
                    }).ToList();
            }
        }
    }
}

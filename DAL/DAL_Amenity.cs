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

        // Thêm đoạn này vào trong class DAL_Amenity hiện tại của bạn
        public bool IsNameExists(string name, long idToIgnore = 0)
        {
            using (var db = new Seoul_StayDataContext())
            {
                return db.Amenities.Any(x => x.Name.ToLower() == name.ToLower() && x.ID != idToIgnore);
            }
        }

        public bool Insert(ET_Amenities et, string iconFileName)
        {
            try
            {
                using (var db = new Seoul_StayDataContext())
                {
                    var amenity = new Amenity // Lưu ý: Tên class entity mapping từ DB có thể là Amenity (không có 's')
                    {
                        GUID = Guid.NewGuid(),
                        Name = et.AmenitiesName,
                        IconName = iconFileName // Chỉ lưu tên file ảnh
                    };
                    db.Amenities.InsertOnSubmit(amenity);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch { return false; }
        }

        public bool Update(ET_Amenities et, string iconFileName)
        {
            try
            {
                using (var db = new Seoul_StayDataContext())
                {
                    var amenity = db.Amenities.FirstOrDefault(x => x.ID == et.ID);
                    if (amenity != null)
                    {
                        amenity.Name = et.AmenitiesName;

                        // Nếu người dùng chọn ảnh mới thì cập nhật IconName
                        if (!string.IsNullOrEmpty(iconFileName))
                        {
                            amenity.IconName = iconFileName;
                        }

                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch { return false; }
        }

        public bool Delete(long id)
        {
            try
            {
                using (var db = new Seoul_StayDataContext())
                {
                    // Kiểm tra xem tiện nghi này có đang được sử dụng ở Item nào không
                    if (db.ItemAmenities.Any(ia => ia.AmenityID == id))
                    {
                        return false; // Đang có Item dùng -> Không cho xóa
                    }

                    var amenity = db.Amenities.FirstOrDefault(x => x.ID == id);
                    if (amenity != null)
                    {
                        db.Amenities.DeleteOnSubmit(amenity);
                        db.SubmitChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch { return false; }
        }
    }
}

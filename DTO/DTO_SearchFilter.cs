using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SearchFilter
    {
        // Từ khoá tìm kiếm (title / area / attraction)
        public string Keyword { get; set; } = "";

        // Giá tối thiểu (null = không lọc)
        public decimal? MinPrice { get; set; }

        // Giá tối đa (null = không lọc)
        public decimal? MaxPrice { get; set; }

        //  Số khách tối thiểu
        public int MinCapacity { get; set; } = 1;

        // Danh sách AmenityID phải có (AND logic)
        public List<long> AmenityIDs { get; set; } = new List<long>();

        // Chỉ lấy listing có ít nhất 1 ngày available trong tương lai
        public bool FilterByAvailability { get; set; } = false;

        /*
          Cách sắp xếp:
           "Default"          – rating DESC
           "Price: Low → High"
           "Price: High → Low"
           "Most Popular"     – reviewCount DESC, rating DESC
           "Newest"           – itemID DESC
        */
        public string SortBy { get; set; } = "Default";
    }
}

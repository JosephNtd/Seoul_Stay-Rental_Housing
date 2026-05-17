using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ItemSearch
    {
        public long ItemID { get; set; }

        public string Title { get; set; }

        public string AreaName { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public decimal PricePerNight { get; set; }

        public int MaxGuests { get; set; }

        public bool IsAvailable { get; set; }

        public string Thumbnail { get; set; }

        public double Score { get; set; }

        public string AttractionName { get; set; }
    }
}

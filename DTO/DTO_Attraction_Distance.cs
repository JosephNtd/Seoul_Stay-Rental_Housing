using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Attraction_Distance
    {
        public long AttractionID { get; set; }
        public string Attraction { get; set; }
        public string Area { get; set; }
        public decimal? Distance { get; set; }
        public long? OnFoot {  get; set; }
        public long? ByCar {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_SuggestionItem
    {
        public string Text { get; set; }  // nội dung gợi ý
        public string Category { get; set; }  // "Listing" | "Area" | "Attraction"

        public override string ToString()
        {
            string prefix;

            switch (Category)
            {
                case "Area":
                    prefix = "📍 ";
                    break;

                case "Attraction":
                    prefix = "🗺 ";
                    break;

                default:
                    prefix = "🏠 ";
                    break;
            }

            return $"{prefix}{Text}";
        }
    }
}

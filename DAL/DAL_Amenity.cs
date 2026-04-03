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
        DataClasses1DataContext db = new DataClasses1DataContext();
        public List<DTO_Amenities> GetData()
        {

            return db.Amenities.Select(p => new DTO_Amenities { Name = p.Name }).ToList();
        }
    }
}

using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ItemType
    {
        Seoul_StayDataContext db = new Seoul_StayDataContext();
        public List<ET_ItemTypes> GetData()
        {
            var data = from t in db.ItemTypes
                       select new ET_ItemTypes
                       {
                           ID = t.ID,
                           Name = t.Name
                       };

            return data.ToList();
        }
    }
}

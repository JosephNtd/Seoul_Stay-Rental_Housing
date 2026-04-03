using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Items
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public List<DTO_ItemsView> GetItems()
        {
            return (from i in db.Items
                    join a in db.Areas on i.AreaID equals a.ID
                    join t in db.ItemTypes on i.ItemTypeID equals t.ID
                    select new DTO_ItemsView
                    {
                        Title = i.Title,
                        Capacity = i.Capacity,
                        Area = a.Name,
                        Type = t.Name
                    }).ToList();
        }
        public bool Add(Item i)
        {
            try
            {
                i.GUID = Guid.NewGuid();
                db.Items.InsertOnSubmit(i);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

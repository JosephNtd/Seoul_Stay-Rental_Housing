using DAL;
using ET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ItemPictures
    {
        private readonly DAL_ItemPictures _dal = new DAL_ItemPictures();

        public List<ET_ItemPictures> LoadPictures(long itemId) => _dal.GetByItem(itemId);

        public void SavePictures(long itemId, List<ET_ItemPictures> pictures) => _dal.SaveAll(itemId, pictures);
    }
}

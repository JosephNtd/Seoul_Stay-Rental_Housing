using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_ItemPictures
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public long ItemID { get; set; }
        public string PictureFileName { get; set; }
        public ET_ItemPictures()
        {
        }

        public ET_ItemPictures(long iD, Guid gUID, long itemID, string pictureFileName)
        {
            ID = iD;
            GUID = gUID;
            ItemID = itemID;
            PictureFileName = pictureFileName;
        }
    }
}

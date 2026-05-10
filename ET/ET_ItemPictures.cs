using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ET
{
    public class ET_ItemPictures
    {
        public long ID { get; set; }
        public string FileName { get; set; }
        public int DisplayOrder { get; set; }
        public string FullPath { get; set; } 
        public bool IsNew { get; set; }
        private Image _imageDisplay;
        public Image ImageDisplay
        {
            get
            {
                // Nếu đã load ảnh rồi thì trả về luôn, không cần đọc lại từ ổ cứng
                if (_imageDisplay != null) return _imageDisplay;

                if (string.IsNullOrEmpty(FullPath) || !File.Exists(FullPath))
                    return null;

                try
                {
                    // Dùng MemoryStream để đọc ảnh không bị lock file
                    byte[] bytes = File.ReadAllBytes(FullPath);
                    _imageDisplay = Image.FromStream(new MemoryStream(bytes));
                    return _imageDisplay;
                }
                catch
                {
                    return null;
                }
            }
        }
        public ET_ItemPictures()
        {   
        }

        public ET_ItemPictures(long iD, string fileName, int displayOrder, string fullPath, bool isNew)
        {
            ID = iD;
            FileName = fileName;
            DisplayOrder = displayOrder;
            FullPath = fullPath;
            IsNew = isNew;
        }
    }
}

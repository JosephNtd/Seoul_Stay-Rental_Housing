using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ET
{
    public class ET_ServiceType
    {
        

        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string Description { get; set; }
        public static Image DefaultIcon { get; set; }
        private Image _imageDisplay;
        public Image Icon
        {
            get
            {
                if (string.IsNullOrEmpty(IconPath))
                    return DefaultIcon;

                try
                {
                    // TRƯỜNG HỢP 1: NẾU NVARCHAR LÀ ĐƯỜNG DẪN FILE
                    if (File.Exists(IconPath))
                    {
                        // Trả về ảnh từ đường dẫn. 
                        // Dùng FromStream thay vì Image.FromFile để tránh lock file trên ổ cứng.
                        using (FileStream fs = new FileStream(IconPath, FileMode.Open, FileAccess.Read))
                        {
                            return Image.FromStream(fs);
                        }
                    }

                    // TRƯỜNG HỢP 2: NẾU NVARCHAR LÀ CHUỖI BASE64
                    byte[] imageBytes = Convert.FromBase64String(IconPath);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
                catch
                {
                    // Nếu đường dẫn sai hoặc Base64 lỗi, trả về ảnh mặc định
                    return DefaultIcon;
                }
            }
        }
        public ET_ServiceType()
        {
        }
        public ET_ServiceType(long iD, Guid gUID, string name, string iconPath, string description)
        {
            ID = iD;
            GUID = gUID;
            Name = name;
            IconPath = iconPath;
            Description = description;
        }
    }
}

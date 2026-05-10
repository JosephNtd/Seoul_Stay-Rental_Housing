using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ET
{
    public class ET_Amenities
    {
        public long ID { get; set; }
        public Guid GUID { get; set; }
        public string AmenitiesName { get; set; }
        public string IconName { get; set; }
        public static Image DefaultIcon { get; set; }

        public ET_Amenities() { }
        public ET_Amenities(long iD, Guid gUID, string name, string iconName)
        {
            ID = iD;
            GUID = gUID;
            AmenitiesName = name;
            IconName = iconName;
        }
        public Image Icon
        {
            get
            {
                if (string.IsNullOrEmpty(IconName))
                    return DefaultIcon;

                try
                {
                    // TRƯỜNG HỢP 1: NẾU NVARCHAR LÀ ĐƯỜNG DẪN FILE
                    if (File.Exists(IconName))
                    {
                        // Trả về ảnh từ đường dẫn. 
                        // Dùng FromStream thay vì Image.FromFile để tránh lock file trên ổ cứng.
                        using (FileStream fs = new FileStream(IconName, FileMode.Open, FileAccess.Read))
                        {
                            return Image.FromStream(fs);
                        }
                    }

                    // TRƯỜNG HỢP 2: NẾU NVARCHAR LÀ CHUỖI BASE64
                    byte[] imageBytes = Convert.FromBase64String(IconName);
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
    }
}

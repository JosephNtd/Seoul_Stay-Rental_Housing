
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_AttractionDisplay
    {
        public long ID { get; set; }
        public System.Guid GUID { get; set; }
        public string AttractionName { get; set; }
        public string Address { get; set; }
        public long AreaID { get; set; }
        public string AreaName { get; set; } // Cột này sẽ hiển thị tên vùng
    }
}

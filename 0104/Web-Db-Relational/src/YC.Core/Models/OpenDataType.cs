using System;
using System.Collections.Generic;
using System.Text;

namespace YC.Models
{
    public class OpenDataType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OpenData> OpenDatas { get; set; }
    }
}

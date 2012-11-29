using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public class mmDTObase
    {
        public DateTime CreateDate { get; set; }
        public int CreateUser { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyUser { get; set; }

    }
}

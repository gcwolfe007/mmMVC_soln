using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public class ContactInfoTypeDTO : mmDTObase
    {
        public int ContactTypeID { get; set; }
        public string TypeDescription { get; set; }
    }
}

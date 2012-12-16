using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public class ContactInfoAssignDTO : mmDTObase
    {
       public ContactInfoAssignDTO() : base() { }
       public int ContactInfoID { get; set; }
       public string ContactInfoItem { get; set; }
       public int ContactInfoTypeID { get; set; }


    }
}

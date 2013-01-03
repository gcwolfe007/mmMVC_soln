using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public class mmDTObase
    {
        public virtual DateTime CreateDate { get; set; }
        public virtual int CreateUserID { get; set; }
        public virtual DateTime ModifyDate { get; set; }
        public virtual int ModifyUser { get; set; }
        public virtual DateTime StartActiveDate { get; set; }
        public virtual DateTime EndActiveDate { get; set; }
    }
}

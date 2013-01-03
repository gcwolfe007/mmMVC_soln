using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public class RenterAccountDTO : mmDTObase
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }    
        public RenterDTO Renter { get; set; }
        
    }
}

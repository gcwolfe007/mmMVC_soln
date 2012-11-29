using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public class RenterDTO : mmDTObase
   {
       public int RenterID { get; set; }
      
       public string FirstName { get; set; }
       public string MiddleName { get; set; }
       public string LastName { get; set; }
   
       public List<AddressAssignDTO> Addresses { get; set; }
       
    }
}

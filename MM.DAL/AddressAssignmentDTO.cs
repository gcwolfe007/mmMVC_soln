using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    /// <summary>
    /// This is the Join Record (Rocky's Assignment)
    /// </summary>
   public class AddressAssignmentDTO : mmDTObase
    {
        public int RenterID { get; set; }
        public int AddressID { get; set; }
        public int AddressType { get; set; }
        public DateTime Assigned { get; set; }  
        public List<AddressDTO> AddressList { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public class AddressAssignDTO : mmDTObase
    {
       public AddressAssignDTO() :base() { }
       public int AddressID { get; set; }
        public int AddressType { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string LineThree { get; set; }
        public string CityTown { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public class TenantInfoDTO
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CityTown { get; set; }
        public string Email { get; set; }

    }
}

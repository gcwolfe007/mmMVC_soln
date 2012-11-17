using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla;
using MM.Library.Collections;

namespace MM.Library.Entities
{
    [Serializable]
    public abstract class RentingParty : BusinessBase<RentingParty>
    {
  

        public abstract int RenterID { get; set; }
        public abstract string CreateDate { get; set; }
        public abstract AddressesEdit Addresses { get; set; }



    }
}

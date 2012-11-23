using System;
using MM.Library.Collections;




namespace MM.Library.Entities
{

    public interface IRentingParty 
    {
        
        int RenterID { get; }

        string CreateDate { get; set; }

        PartyAddresses Addresses { get; set; }

   }

}

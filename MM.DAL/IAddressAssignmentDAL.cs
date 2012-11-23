using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public interface IAddressAssignmentDAL

    {
       AddressAssignmentDTO Fetch(int partyID, int addressId);
       List<AddressAssignmentDTO> FetchForParty(int partyID);
       List<AddressAssignmentDTO> FetchForAddress(int addressId);
       void Insert(AddressAssignmentDTO item);
       void Update(AddressAssignmentDTO item);
       void Delete(int partyID, int addressId);
   

    }
}

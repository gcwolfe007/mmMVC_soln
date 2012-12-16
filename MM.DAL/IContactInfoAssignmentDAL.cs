using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IContactInfoAssignmentDAL
    {
        ContactInfoAssignmentDTO Fetch(int partyID, int contactInfoitemID);
        List<ContactInfoAssignmentDTO> FetchForParty(int partyID);
        List<ContactInfoAssignmentDTO> FetchForContactInfoItem(int contactInfoitemIDsId);
        void Insert(ContactInfoAssignmentDTO item);
        void Update(ContactInfoAssignmentDTO item);
        void Delete(int partyID, int addressId);
    }
}

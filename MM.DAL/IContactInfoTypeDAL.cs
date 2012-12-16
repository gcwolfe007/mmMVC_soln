using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IContactInfoTypeDAL
    {
        List<ContactInfoTypeDTO> Fetch();
        ContactInfoTypeDTO Fetch(int id);
        void Insert(AddressTypeDTO item);
        void Update(AddressTypeDTO item);
        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IAddressTypeDAL
    {
        List<AddressTypeDTO> Fetch();
        AddressTypeDTO Fetch(int id);
        void Insert(AddressTypeDTO item);
        void Update(AddressTypeDTO item);
        void Delete(int id);
    }
}

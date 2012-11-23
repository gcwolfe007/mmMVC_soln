using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IAddressDAL
    {
        AddressDTO Fetch(int id);
        bool Exists(int id);
        void Insert(AddressDTO item);
        void Update(AddressDTO item);
        void Delete(int id);
    }
}

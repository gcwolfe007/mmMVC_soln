using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IContactInfo
    {
        ContactInfoDTO Fetch(int id);
        bool Exists(int id);
        void Insert(ContactInfoDTO item);
        void Update(ContactInfoDTO item);
        void Delete(int id);
    }
}

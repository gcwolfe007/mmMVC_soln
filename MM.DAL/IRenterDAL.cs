using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public interface IRenterDAL
    {
        List<RenterDTO> Fetch();
        RenterDTO Fetch(int id);
        bool Exists(int id);
        void Insert(RenterDTO item);
        void Update(RenterDTO item);
        void Delete(int id);
    }
}

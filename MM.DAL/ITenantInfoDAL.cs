using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
   public interface ITenantInfoDAL
    {
      
       TenantInfoDTO Fetch(int id);
        bool Exists(int id);
     

    }
}

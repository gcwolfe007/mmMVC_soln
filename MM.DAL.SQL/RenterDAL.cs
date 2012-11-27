using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MM.DAL;


namespace MM.DAL.SQL
{
   public class RenterDAL : IRenterDAL
    {
        #region IRenterDAL Members

        public List<RenterDTO> Fetch()
        {
            throw new NotImplementedException();
        }

        public RenterDTO Fetch(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(RenterDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(RenterDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

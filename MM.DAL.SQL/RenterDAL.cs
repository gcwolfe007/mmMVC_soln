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


       const string sp_InsertRenter = "SP_INSERT_RENTER";



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

        public void Insert(mmDTObase myDTO)
        {
            
            using (var mySQL = new SQL.StoredProcedures.SP_INSERT_RENTER(sp_InsertRenter))
            {
                var myResult = mySQL.ExecuteSP(myDTO);
                var data = (SQL.Results.spR_Insert_Renter_Result)myResult;
                if (data.ErrorMessage.Length > 0)
                {
                    throw new Exception(data.ErrorMessage);
                }
               
            } 
        }

        public void Update(mmDTObase item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRenterDAL Members


        public void Insert(RenterDTO item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

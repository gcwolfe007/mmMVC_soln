using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MM.DAL;


namespace MM.DAL.SQL
{
   public class RenterAccountDAL : IRenterAccountDAL
    {
        #region IRenterAccountDAL Members


       const string sp_InsertRenter = "Insert_Account_Assignment";
       const string sp_GetTenantList = "Get_TenantInfo_List";
       const string sp_GetAccount = "Get_Account_Info_by_AccountID";


       public List<TenantInfoDTO> FetchTenants()
       {
           using (var mySQL = new SQL.StoredProcedures.SP_Get_TenantInfo_List(sp_GetTenantList))
           {
               var myResult = mySQL.ExecuteSP();
               var data = (SQL.Results.spR_Get_TenantsInfo_List_Result)myResult;
               if (data.ErrorMessage.Length > 0)
               {
                   throw new Exception(data.ErrorMessage);
               }
               return data.ResultSet;
           } 
       }

       public List<TenantInfoDTO> FetchTenants(string name)
       {
           throw new NotImplementedException();
       }
  

        public List<RenterAccountDTO> Fetch()
        {
            throw new NotImplementedException();
        }

        public RenterAccountDTO Fetch(int id)
        {
            using (var mySQL = new SQL.StoredProcedures.SP_Get_Account_Info_by_AccountID(sp_GetAccount))
            {
                var myResult = mySQL.ExecuteSP(id);
                var data = (SQL.Results.spR_Get_Account_Info_by_AccountID_Result)myResult;
                if (data.ErrorMessage.Length > 0)
                {
                    throw new Exception(data.ErrorMessage);
                }
                return data.ResultSet;
            } 
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






    }
}

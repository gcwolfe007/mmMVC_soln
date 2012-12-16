using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL
{
    public class ContactInfoTypeDAL : IContactInfoTypeDAL
    {
        const string sp_GetContactInfoTypes = "Get_ContactInfoTypes_List";

        #region IContactInfoTypeDAL Members

        public List<ContactInfoTypeDTO> Fetch()
        {
            using (var mySQL = new SQL.StoredProcedures.SP_Get_ContactInfoType_List(sp_GetContactInfoTypes))
            {
                var myResult = mySQL.ExecuteSP();
                var data = (SQL.Results.spR_Get_ContactInfoTypes_List_Result)myResult;
                if (data.ErrorMessage.Length > 0)
                {
                    throw new Exception(data.ErrorMessage);
                }
                return data.ResultSet;

            } 
        }

        public ContactInfoTypeDTO Fetch(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AddressTypeDTO item)
        {
            throw new NotImplementedException();
        }

        public void Update(AddressTypeDTO item)
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

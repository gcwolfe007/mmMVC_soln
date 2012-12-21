using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL
{
    public class AddressTypesDAL : IAddressTypesDAL
    {
        #region IAddressTypeDAL Members

        const string sp_GetAddressTypes = "Get_AddressTypes_List";

        public List<AddressTypeDTO> Fetch()
        {
            using (var mySQL = new SQL.StoredProcedures.SP_Get_AddressTypes_List(sp_GetAddressTypes))
            {
                var myResult = mySQL.ExecuteSP();
                var data = (SQL.Results.spR_Get_AddressTypes_List_Result)myResult;
                if (data.ErrorMessage.Length > 0)
                {
                    throw new Exception(data.ErrorMessage);
                }
                return data.ResultSet;
            }
        }

        public AddressTypeDTO Fetch(int id)
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

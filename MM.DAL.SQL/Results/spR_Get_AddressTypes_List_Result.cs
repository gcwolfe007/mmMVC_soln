using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL.Results
{
    public class spR_Get_AddressTypes_List_Result : spResult
    {

        protected List<AddressTypeDTO> _resultSet = new List<AddressTypeDTO>();
        
        /// <summary>
        /// Gets the error message.
        /// </summary>
        public override string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            internal set
            {
                _errorMessage = value;
            }
        }

        /// <summary>
        /// Gets the rows returned.
        /// </summary>
        public override int RowsReturned
        {
            get
            {
                return _rowsReturned;
            }
            internal set
            {
                _rowsReturned = value;
            }
        }

        public List<AddressTypeDTO> ResultSet
        {
            get
            {
                return _resultSet;
            }

            set 
            {
               _resultSet = value;
            }
        
        
        }



    }
}
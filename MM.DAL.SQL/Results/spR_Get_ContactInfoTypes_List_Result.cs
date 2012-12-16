using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL.Results
{
    public class spR_Get_ContactInfoTypes_List_Result : spResult
    {

        protected List<ContactInfoTypeDTO> _resultSet;
        
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

        public List<ContactInfoTypeDTO> ResultSet
        {
            get
            {
                return _resultSet;
            }

            set 
            {
                value = _resultSet;
            }
        
        
        }



    }
}

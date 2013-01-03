using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL.Results
{
    public class spR_Get_Account_Info_by_AccountID_Result : spResult
    {

        protected RenterAccountDTO _resultSet;
        
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

        public RenterAccountDTO ResultSet
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL.Results
{
   public class spR_Insert_Renter_Result : spResult
    {
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
    }
}

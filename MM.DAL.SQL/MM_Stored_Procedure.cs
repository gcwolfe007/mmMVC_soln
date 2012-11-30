using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MM.DAL.SQL
{
    public abstract class MM_Stored_Procedure : IDisposable
    {
        protected string _storedProcedureName;
        protected List<SqlParameter> _parameters = new List<SqlParameter>();
        protected SqlConnection _mySQLConn = new SqlConnection();
      

        public MM_Stored_Procedure(string requestedSP) { }

        protected string CreateUIMessage(string exMessage)
        {
            var myStart = "While attempting to execute stored procedure " + _storedProcedureName + ": Received Error or Warning: - <br><br><span Style='color:Green'>  ";

            var ibmEnd = exMessage.IndexOf('"');
            var errString = exMessage;
            if (ibmEnd > 0)
            {
                errString = exMessage.Remove(0, ibmEnd);
            }

            return myStart + errString + "</span>";


        }
        #region IDisposable Members

        public abstract void Dispose();
  

        #endregion
    }
}

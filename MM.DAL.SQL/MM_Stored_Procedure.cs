using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL
{
    public abstract class MM_Stored_Procedure : IDisposable
    {
        protected string _storedProcedureName;

        public MM_Stored_Procedure(string requestedSP) { }


        #region IDisposable Members

        public abstract void Dispose();
  

        #endregion
    }
}

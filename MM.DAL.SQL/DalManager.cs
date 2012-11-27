using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Csla.Data;
using System.Data.SqlClient;
using System.Configuration;




namespace MM.DAL.SQL
{
   public class DalManager :  MM.DAL.IDalManager
    {
       private static string _typeMask = typeof(DalManager).FullName.Replace("DalManager", @"{0}");

        #region IDalManager Members

        public T GetProvider<T>() where T : class
        {
            var typeName = string.Format(_typeMask, typeof(T).Name.Substring(1));
            var type = Type.GetType(typeName);
            if (type != null)
                return Activator.CreateInstance(type) as T;
            else
                throw new NotImplementedException(typeName);
        }

        public SqlConnection ConnectionManager { get; private set; }

        public DalManager()
        {
            var cnStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ConnectionManager = new SqlConnection(cnStr);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            ConnectionManager.Dispose();
            ConnectionManager = null;
        }

        #endregion
    }
}

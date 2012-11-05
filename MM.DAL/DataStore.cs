using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{
    public abstract class  DataStore :IDisposable
    {


        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

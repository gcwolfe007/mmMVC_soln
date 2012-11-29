using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL.SQL
{
   public abstract class spResult
    {
       protected string _errorMessage;
       protected int _rowsReturned;
       public abstract string ErrorMessage { get; internal set; }
       public abstract int RowsReturned { get; internal set; }
    }
}

using System;
using System.Configuration;

namespace MM.DAL
{
public class DalFactory
    {
      public static DataStore GetDataStore()
      {
          var dalType = Type.GetType(ConfigurationManager.AppSettings["RentalBusinessData"], true, true);
          return (DataStore)Activator.CreateInstance(dalType);
      }


    }
}

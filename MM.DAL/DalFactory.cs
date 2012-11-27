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


      private static Type _dalType;

      public static IDalManager GetManager()
      {
          if (_dalType == null)
          {
              var dalTypeName = ConfigurationManager.AppSettings["DalManagerType"];
              if (!string.IsNullOrEmpty(dalTypeName))
                  _dalType = Type.GetType(dalTypeName);
              else
                  throw new NullReferenceException("The DalManagerType is Not Configured!");
              if (_dalType == null)
                  throw new ArgumentException(string.Format("Type {0} could not be found", dalTypeName));
          }
          return (IDalManager)Activator.CreateInstance(_dalType);
      }


    }
}

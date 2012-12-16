using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Resources;
using MM.DAL;
using System.Data;
using System.Data.SqlClient;
using MM.DAL.SQL.Properties;

namespace MM.DAL.SQL
{
      
    public class DataMapper
    {
        
        internal static IList<SqlParameter> CreateCriteriaParameters(mmDTObase myDTO)
        {
            var _parameters = new List<SqlParameter>();
            var myStuff = DataMapper.GetDTOproperties(myDTO);

            ResourceManager rm = new ResourceManager("MM.DAL.SQL.Properties.Resources", Assembly.GetExecutingAssembly());
            foreach (PropertyInfo pi in myStuff)
            {
                var suffix = pi.Name.ToLower();
                var dbType = GetParmType(pi.PropertyType.Name);
                var myValue = pi.GetValue(myDTO, null);
                var parameterName = rm.GetString("p_" + suffix);
                var myParm = new SqlParameter(parameterName, dbType);
                myParm.Value = myValue;                 
                _parameters.Add(myParm);
            }
            return _parameters;
        }
              
        //internal static IList<SqlParameter> CreateInsertParameters(RenterDTO myDTO)
        //{
        //    var _parameters = new List<SqlParameter>();
        //    var myStuff = DataMapper.GetDTOproperties(myDTO);
        //    ResourceManager rm = new ResourceManager("MM.DAL.SQL.Properties.Resources", Assembly.GetExecutingAssembly());
        //    foreach (PropertyInfo pi in myStuff)
        //    {
        //        var suffix = pi.Name.ToLower();
        //        var dbType = GetParmType(pi.PropertyType.Name); 
        //        var myValue = pi.GetValue(myDTO, null);
        //        var parameterName = rm.GetString("p_"+ suffix);                    
        //        if (parameterName != Resources.p_carddata)
        //        {
        //            var myParm = GetTransactParameter(dbType, ref myValue, parameterName);
        //            if (myParm.ParameterName != Resources.p_seqstr5)
        //            {
        //                _parameters.Add(myParm);
        //            }
        //        }
        //        else
        //        { 
        //            _parameters.Add(GetCardDataParameter(parameterName, myDTO)); 
        //        }
        //    }
        //    var tinParm = new SqlParameter(Resources.p_tinctl, DB2Type.VarChar);
        //    tinParm.Value = myDTO.Cards[0].TinControl;
        //    _parameters.Insert(_parameters.Count - 3 , tinParm);           
        //    // Add the OUTPUT parameter (P_NEXTSEQNO)
        //    var outputParm = new SqlParameter(Resources.p_nextseqno, DB2Type.VarChar);
        //    outputParm.Direction = System.Data.ParameterDirection.Output;
        //    _parameters.Add(outputParm);  

        //    return _parameters;            
        //}   

        //internal static IList<SqlParameter> CreateUpdateParameters(TransactionDTO myDTO)
        //{
        //    var _parameters = new List<SqlParameter>();
        //    var myStuff = DataMapper.GetDTOproperties(myDTO); 
        //    ResourceManager rm = new ResourceManager("MM.DAL.SQL.Properties.Resources", Assembly.GetExecutingAssembly());
        //    foreach (PropertyInfo pi in myStuff)
        //    {
        //        var suffix = pi.Name.ToLower();
        //        var dbType = GetParmType(pi.PropertyType.Name);
        //        var myValue = pi.GetValue(myDTO, null);
        //        var parameterName = rm.GetString("p_" + suffix);                
        //        if (parameterName != Resources.p_carddata)
        //        {
        //            var myParm = GetTransactParameter(dbType, ref myValue, parameterName);
        //            if (myParm.ParameterName != Resources.SeqNo)
        //            {
        //                _parameters.Add(myParm);
        //            }
        //        }
        //        else
        //        {
        //           _parameters.Add(GetCardDataParameter(parameterName, myDTO));
        //        } 
        //    }
        //    // Add the TINCTL parameter
        //    var tinParm = new SqlParameter(Resources.p_tinctl, DB2Type.VarChar);
        //    tinParm.Value = myDTO.Cards[0].TinControl;
        //    _parameters.Insert(_parameters.Count - 3, tinParm);
            
        //    return _parameters;
        //}

        #region Supporting Methods

        //private static SqlParameter GetTransactParameter(SqlDbType dbType, ref object myValue, string parameterName)
        //    {
        //        var myParm = new SqlParameter(parameterName, dbType);

        //        if (dbType == SqlDbType.Timestamp)
        //        {
        //            if (parameterName == Resources.p_createdatetime)
        //            {
        //                var mydate = DateTime.Now;
        //                myParm.Value = Helpers.GetTimestamp(mydate);
        //            }
        //            else
        //            {
        //                myParm.Value = null;
        //            }
        //        }
        //        else
        //        {
        //            if (parameterName == Resources.p_amount)
        //                myValue = Convert.ToInt32(myValue);
        //            myParm.Value = myValue;
        //        }
        //        return myParm;
        //    }

            //private static SqlParameter GetCardDataParameter(string parmName, TransactionDTO myDTO)
            //{
            //    var myParm = new SqlParameter(parmName, DB2Type.DynArray);
            //    myParm.Direction = System.Data.ParameterDirection.Input;
            //    var cardArray = GetCardArray(myDTO.Cards);
            //    myParm.ArrayLength = cardArray.Length;
            //    myParm.Value = cardArray;
            //    return myParm;
            //}

            //private static string[] GetCardArray(List<CardDataDTO> myCards)
            //{
            //    var myrows = myCards.Count;
            //    string[] myArray = new string[myrows];
            //    for (int i = 0; i < myCards.Count; i++)
            //    {
            //        myArray[i] = myCards[i].CardData;
            //    }
            //    return myArray;
            //}

            private static SqlDbType GetParmType(string myType)
            {

                switch (myType)
                {
                    case "Char":
                        return SqlDbType.Char;
                    case "String":
                        return SqlDbType.VarChar;
                    case "DateTime":
                        return SqlDbType.DateTime;
                    case "Nullable`1":
                        return SqlDbType.VarChar;
                    case "SmartDate":
                        return SqlDbType.DateTime;
                    case "double":
                        return SqlDbType.Char;
                    case "List`1":
                        return SqlDbType.Structured;
                    default:
                        return SqlDbType.Char;
                }


            }

            internal static IList<PropertyInfo> GetDTOproperties(mmDTObase myDTO)
            {
                var sourceType = myDTO.GetType();
                var sourceProperties = sourceType.GetProperties();

                var properties = (from s in sourceProperties
                                  select s).ToList();
                return properties;
            }

            /// <summary>
            ///     Copying matching properties – non-optimized version
            ///     
            ///     Our first version of properties copying code is straight-forward
            ///     and we don’t use any optimizations. We just want to see so called
            ///    zero-results to get some base metric for optimizations.
            ///     So, here is the code that does exactly what we need.
            /// </summary>
            /// <param name="source"></param>
            /// <param name="target"></param>
            public static void CopyProperties(object source, object target)
            {
                var sourceType = source.GetType();
                var targetType = target.GetType();
                var propMap = GetMatchingProperties(sourceType, targetType);

                for (var i = 0; i < propMap.Count; i++)
                {
                    var prop = propMap[i];
                    var sourceValue = prop.SourceProperty.GetValue(source, null);
                    prop.TargetProperty.SetValue(target, sourceValue, null);
                }
            }

            public IList<PropertyInfo> GetMatchingProperties(object source, object target)
            {
                if (source == null)
                    throw new ArgumentNullException("source");
                if (target == null)
                    throw new ArgumentNullException("target");

                var sourceType = source.GetType();
                var sourceProperties = sourceType.GetProperties();
                var targetType = target.GetType();
                var targetProperties = targetType.GetProperties();

                var properties = (from s in sourceProperties
                                  from t in targetProperties
                                  where s.Name == t.Name &&
                                        s.PropertyType == t.PropertyType
                                  select s).ToList();
                return properties;
            }

            public static IList<PropertyMap> GetMatchingProperties(Type sourceType, Type targetType)
        {
            var sourceProperties = sourceType.GetProperties();
            var targetProperties = targetType.GetProperties();

            var properties = (from s in sourceProperties
                              from t in targetProperties
                              where s.Name == t.Name &&
                                    s.CanRead &&
                                    t.CanWrite &&
                                    s.PropertyType.IsPublic &&
                                    t.PropertyType.IsPublic &&
                                    s.PropertyType == t.PropertyType &&
                                    (
                                      (s.PropertyType.IsValueType &&
                                       t.PropertyType.IsValueType
                                      ) ||
                                      (s.PropertyType == typeof(string) &&
                                       t.PropertyType == typeof(string)
                                      )
                                    )
                              select new PropertyMap
                              {
                                  SourceProperty = s,
                                  TargetProperty = t
                              }).ToList();

            return properties;
        }                      
       
        #endregion  
    }

    public class PropertyMap
    {

        public PropertyInfo SourceProperty { get; set; }   
        public PropertyInfo TargetProperty { get; set; }

    }


}

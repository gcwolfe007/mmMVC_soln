using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Csla.Data;
using MM.DAL;
using MM.DAL.SQL.Results;
using MM.DAL.SQL.Properties;
using AutoMapper;

namespace MM.DAL.SQL.StoredProcedures
{
    public class SP_Get_AddressTypes_List : MM_Stored_Procedure
    {

#region Constructors

         /// <summary>
        /// Initializes a new instance of the <see cref="SP_INSERT_RENTER"/> class.
         /// </summary>
         /// <param name="requestedSP">The requested SP.</param>
        public SP_Get_AddressTypes_List(string requestedSP)
             : base(requestedSP)         
         {
             _storedProcedureName = requestedSP;
             CreateMaps();
             
         }

       #endregion


        #region Methods

        
          
        /// <summary>
         /// Executes the SP.
         /// </summary>
         /// <returns>spResult object</returns>
       public spResult ExecuteSP() 
       {
           var myData = new DalManager();
             var myResult = new spR_Get_AddressTypes_List_Result();
             if (myData.GetConnection(out _mySQLConn)) return null; 
             try
             {
                 using (var myAccessCommand = new SqlCommand(_storedProcedureName, _mySQLConn))
                 {
                     myAccessCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    var myCount = myAccessCommand.Parameters.Count;
                                        
                    _mySQLConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                     {
                         var rdrResult = Mapper.Map<List<AddressTypeDTO>>(dr);
                         myResult.RowsReturned = rdrResult.Count;
                         // Get the next resultset (Cards) from the DataReader
                         //  dr.NextResult();
                         // LoadCardData(dr);

                         myResult.ResultSet = rdrResult;
                     }                     
                    }
                return myResult;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error: Failed to act on the data in the DataBase.\n{0}", ex.Message);
                myResult.ErrorMessage = CreateUIMessage(ex.Message);
                return myResult;
            }
            finally
            {
                _mySQLConn.Close();
            }   
       }

       private void CreateMaps()
       {
           // Parent - 
           Mapper.CreateMap<SafeDataReader, AddressTypeDTO>()           
           ;
           // Child etc - 
       }

     

       public override void Dispose()
       {
           _mySQLConn.Dispose();
       }

        #endregion
    }
}

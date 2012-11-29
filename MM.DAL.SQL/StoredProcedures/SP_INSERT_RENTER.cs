﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MM.DAL;
using MM.DAL.SQL.Results;
using MM.DAL.SQL.Properties;

namespace MM.DAL.SQL.StoredProcedures
{
   public class SP_INSERT_RENTER : MM_Stored_Procedure
    {
        #region Constructors

         /// <summary>
        /// Initializes a new instance of the <see cref="SP_INSERT_RENTER"/> class.
         /// </summary>
         /// <param name="requestedSP">The requested SP.</param>
         public SP_INSERT_RENTER(string requestedSP)
             : base(requestedSP)         
         {
             _storedProcedureName = requestedSP;
             
         }
         
         
         #endregion

        #region Methods
          
        /// <summary>
         /// Executes the SP.
         /// </summary>
         /// <returns>spResult object</returns>
         public spResult ExecuteSP(mmDTObase myDTO)
         {
             var myData = new DalManager();
             var myResult = new spR_Insert_Renter_Result();
             if (myData.ConnectionManager(out _myDB2Conn)) return null; 
             try
             {
                 using (var myAccessCommand = new SqlCommand(_storedProcedureName, _myDB2Conn))
                 {
                     myAccessCommand.CommandType = System.Data.CommandType.StoredProcedure;
                     var myStuff = DataMapper.CreateCriteriaParameters(myDTO);
                     foreach (SqlParameter parm in myStuff)
                     {
                         if (parm.ParameterName.Length > 0)
                         {
                            myAccessCommand.Parameters.Add(parm);
                            System.Diagnostics.Debug.WriteLine("Parameter: " + parm.ParameterName + " - Value: " + parm.Value);
                         }
                     }
                     _myDB2Conn.Open();
                     myResult.RowsReturned = myAccessCommand.ExecuteNonQuery();   
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
                _myDB2Conn.Close();
            }       
         }

         /// <summary>
         ///    Gets Cards pertaining to a Transaction
         /// </summary>
         /// <param name="cardData"></param>
         /// <param name="index"></param>
         /// <returns></returns>
         //private CardDataDTO GetCard(string cardData, int index)
         //{
         //    var myCard = new CardDataDTO { CardData = cardData, CardNo = index };
         //    return myCard;
         //}
        
         public override void Dispose()
         {
             if (_myDB2Conn.IsOpen)
             {
                 _myDB2Conn.Close();
              }
             _myDB2Conn.Dispose();
            
         }
        
         #endregion

    }
}

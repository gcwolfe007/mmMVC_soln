using System;
using System.Linq;
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
             if (myData.GetConnection(out _mySQLConn)) return null; 
             try
             {
                 using (var myAccessCommand = new SqlCommand(_storedProcedureName, _mySQLConn))
                 {
                     myAccessCommand.CommandType = System.Data.CommandType.StoredProcedure;

                     //Get the Address parms for sure
                     var concDTO = (RenterAccountDTO)myDTO;
                     var address = concDTO.Renter.Addresses[0];
                     var myAddresStuff = DataMapper.CreateCriteriaParameters(address);
                     foreach (SqlParameter parm in myAddresStuff)
                     {
                         if (parm.ParameterName.Length > 0)
                         {
                             myAccessCommand.Parameters.Add(parm);
                             System.Diagnostics.Debug.WriteLine("Parameter: " + parm.ParameterName + " - Value: " + parm.Value);
                         }
                     }
                     var phone = concDTO.Renter.ContactInfoItems[0];
                     myAccessCommand.Parameters.AddWithValue("@Phone", phone.ContactInfoItem);
                     myAccessCommand.Parameters.AddWithValue("@ContactType", phone.ContactInfoTypeID);



                     var myStuff = DataMapper.CreateCriteriaParameters(concDTO.Renter);
                     foreach (SqlParameter parm in myStuff)
                     {
                         if (parm.ParameterName.Length > 0)
                         {
                            myAccessCommand.Parameters.Add(parm);
                            System.Diagnostics.Debug.WriteLine("Parameter: " + parm.ParameterName + " - Value: " + parm.Value);
                         }        
                     }

                     var query = from SqlParameter myparm in myAccessCommand.Parameters
                                 where myparm.ParameterName == "@RenterID"
                                 select myparm;
                     var outParm = query.FirstOrDefault();
                     outParm.DbType = System.Data.DbType.Int32;
                     outParm.Direction = System.Data.ParameterDirection.Output;
                     outParm.ParameterName = "@AccountID";

                     myAccessCommand.Parameters.AddWithValue("@UserID", concDTO.Renter.CreateUserID);

                     var myCount = myAccessCommand.Parameters.Count;

                     _mySQLConn.Open();
                      myResult.RowsReturned =  myAccessCommand.ExecuteNonQuery();
                     concDTO.Renter.RenterID = (int)myAccessCommand.Parameters["@AccountID"].Value;
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
     
             _mySQLConn.Dispose();
            
         }
        
         #endregion

    }
}

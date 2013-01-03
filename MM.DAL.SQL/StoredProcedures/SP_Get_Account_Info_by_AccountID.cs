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
   public class SP_Get_Account_Info_by_AccountID : MM_Stored_Procedure
   {
       protected RenterAccountDTO _myDTO = new RenterAccountDTO();
       #region Constructors

         /// <summary>
        /// Initializes a new instance of the <see cref="SP_INSERT_RENTER"/> class.
         /// </summary>
         /// <param name="requestedSP">The requested SP.</param>
       public SP_Get_Account_Info_by_AccountID(string requestedSP)
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
       public spResult ExecuteSP(int accountID) 
       {
           var myData = new DalManager();
             var myResult = new spR_Get_Account_Info_by_AccountID_Result();
             if (myData.GetConnection(out _mySQLConn)) return null; 
             try
             {
                 using (var myAccessCommand = new SqlCommand(_storedProcedureName, _mySQLConn))
                 {
                     myAccessCommand.CommandType = System.Data.CommandType.StoredProcedure;
                     myAccessCommand.Parameters.AddWithValue("@AccountID", accountID);

                     _mySQLConn.Open();
                     using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                     {
                         var rdrResult = Mapper.Map<List<RenterAccountDTO>>(dr);
                         _myDTO = rdrResult.FirstOrDefault();
                         myResult.RowsReturned = rdrResult.Count;
                        // Get the next resultset (Cards) from the DataReader
                        dr.NextResult();
                        LoadRenterData(dr);
                        dr.NextResult();
                        LoadAddresses(dr);
                        dr.NextResult();
                        LoadContactInfoItems(dr);

                        myResult.ResultSet = _myDTO;
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
       
       private void LoadRenterData(SafeDataReader dr)
       {
           var myPerson = Mapper.Map<List<RenterDTO>>(dr);
           _myDTO.Renter = myPerson.FirstOrDefault();     
       
       }

       private void LoadAddresses(SafeDataReader dr)
       {
           _myDTO.Renter.Addresses = Mapper.Map<List<AddressAssignDTO>>(dr);
       }


       private void LoadContactInfoItems(SafeDataReader dr)
       {
           _myDTO.Renter.ContactInfoItems = Mapper.Map<List<ContactInfoAssignDTO>>(dr);
       }

       private void CreateMaps()
       {
           // Parent - 
           Mapper.CreateMap<SafeDataReader, RenterAccountDTO>()
            .ForMember(dest => dest.Renter, opt => opt.Ignore());
            ;

            // Children - Renter
            Mapper.CreateMap<SafeDataReader, RenterDTO>()
                   .ForMember(dest => dest.Addresses, opt => opt.Ignore())
                   .ForMember(dest => dest.ContactInfoItems, opt => opt.Ignore())
            ;


            Mapper.CreateMap<SafeDataReader, AddressAssignDTO>()
                ;

            Mapper.CreateMap<SafeDataReader, ContactInfoAssignDTO>()
                ;

    
           Mapper.AssertConfigurationIsValid();

           // Child etc - 
       }


    
     

       public override void Dispose()
       {
           _mySQLConn.Dispose();
       }

        #endregion
    }
}


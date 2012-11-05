using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using Csla.Data;
using MM.DTO;

namespace MM.DAL.DTO
{
    public class MiniManagerDataAccess : DAL.RentalBusinessData
    {

        #region MS Access.MDB SQL Strings

          const string MMSQLRentalBusinessInfo =
                @"SELECT
                    F.[FacilityID],
                    F.[FacilityName], 
                    F.[StreetAddress], 
                    F.[City],
                    F.[State],
                    F.[Zip],
                    F.[Phone]
                  FROM tblFacilities F
                  WHERE F.[MainAddress]=True;";

          const string MMSQLGetAccounts =
              @"SELECT C.CustomerID, C.Line1, C.Line2, C.Line3, C.Line4, C.Line5, Sum(T.Amount) AS Balance
                               FROM tblCustomers C 
                                  INNER JOIN tblTransactions T 
                                   ON C.CustomerID = T.CustomerID 
                               GROUP BY C.CustomerID, C.Line1, C.Line2, C.Line3, C.Line4, C.Line5";

          const string MMSQLGetStorageUnits =
              @"SELECT
                    U.CustomerID, 
                    F.FacilityName,
                    B.BldgNumber,
                    U.UnitNumber,
                    U.UnitRate, 
                    U.UnitStatus,
                    S.[Size] AS UnitSize
                FROM ((tblFacilities AS F 
                INNER JOIN tblBuildings AS B 
                ON F.FacilityID = B.FacilityID) 
                INNER JOIN tblStorageUnits AS U 
                ON B.BldgNumber = U.BldgNumber) 
                INNER JOIN tblSizes AS S 
                ON U.SizeID = S.SizeID
                Where U.CustomerID <>0";
         
            const string MMSQLGetContactItems =
                @"SELECT tblPhones.PhoneID,
                      tblPhones.CustomerID,
                      tblPhones.PhoneNumber,
                      tblPhones.Caption
                  FROM tblPhones;";
        
            const string MMSQLGetMonthsPosted =
                @"SELECT tblTransactions.RentalDate 
                    From tblTransactions 
                    GROUP BY tblTransactions.RentalDate, tblTransactions.TranCode 
                    Having Day([RentalDate]) = 1 AND tblTransactions.TranCode='M_Rental' 
                    ORDER BY tblTransactions.RentalDate DESC";
        
            const string MMSQLGetTransactionsByID =
                @"Select * FROM tblTransactions Where CustomerID=";
           

        
        #endregion

        private int _accountIDParm = 0;
        private string _cnstr = DatabaseInfo.GetConnectionString();
        private List<AccountDTO> myaccountDTOs = new List<AccountDTO>();
        private List<TransactionDTO> mytransactionDTOs = new List<TransactionDTO>(); 
        private List<StorageUnitDTO> mystorageUnitDTOs = new List<StorageUnitDTO>();
        private List<ContactItemDTO> myContactItemDTOs = new List<ContactItemDTO>();
        private DatabaseInfo myData = new DatabaseInfo();
        private OleDbConnection _myAccessConn;
        private RentalBusinessDTO _myBusinessInfo;

        public override List<AccountDTO> GetAccounts()
        {
      
            if (myData.GetConnection(out _myAccessConn)) return null;
            try
            {
                using (var myAccessCommand = new OleDbCommand(MMSQLGetAccounts, _myAccessConn))
                {
                    _myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            var myaccountDTO = new AccountDTO
                                                   {
                                                       AccountID = dr.GetInt32(dr.GetOrdinal("CustomerID")),
                                                       Line1 = dr.GetString(dr.GetOrdinal("Line1")),
                                                       Line2 = dr.GetString(dr.GetOrdinal("Line2")),
                                                       Line3 = dr.GetString(dr.GetOrdinal("Line3")),
                                                       Line4 = dr.GetString(dr.GetOrdinal("Line4")),
                                                       Line5 = dr.GetString(dr.GetOrdinal("Line5")),
                                                       Balance = dr.GetDecimal(dr.GetOrdinal("Balance")),
                                                   };
                            myaccountDTOs.Add(myaccountDTO);
                        }
                }
                LoadStorageUnits();
                MergeStorageUnits();
                LoadContactItems();
                MergeContactItems();
                return myaccountDTOs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return null;
            }
            finally
            {
                _myAccessConn.Close();
            }
        }

        public override RentalBusinessDTO GetRentalBusinessInfo()
        {
            if (myData.GetConnection(out _myAccessConn)) return null;
            var businessInfo = new RentalBusinessDTO();
            try
            {
                using (var myAccessCommand = new OleDbCommand(MMSQLRentalBusinessInfo, _myAccessConn))
                {
                    _myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            {
                                businessInfo.BusinessName = dr.GetString(dr.GetOrdinal("FacilityName"));
                                businessInfo.Address = dr.GetString(dr.GetOrdinal("StreetAddress"));
                                businessInfo.City = dr.GetString(dr.GetOrdinal("City"));
                                businessInfo.StateProvince = dr.GetString(dr.GetOrdinal("State"));
                                businessInfo.PostalCode = dr.GetString(dr.GetOrdinal("Zip"));
                                businessInfo.PhoneNumber = dr.GetString(dr.GetOrdinal("Phone"));
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
            }
            finally
            {
                _myAccessConn.Close();
            }
            return businessInfo;
        }

        public override List<TransactionDTO> GetTransactions(int accountID)
        {

            _accountIDParm = accountID;
            var myParm = _accountIDParm.ToString(CultureInfo.InvariantCulture);
            var getAccountTransactions = MMSQLGetTransactionsByID + myParm;
            if (myData.GetConnection(out _myAccessConn)) return null;
            try
            {
                using (var myAccessCommand = new OleDbCommand(getAccountTransactions, _myAccessConn))
                {
                    _myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            var myTransactionDTO = new TransactionDTO
                            {
                                TransactionID = dr.GetInt32(dr.GetOrdinal("TransactionID")),
                                AccountID = dr.GetInt32(dr.GetOrdinal("CustomerID")),
                                TransactionDate = dr.GetSmartDate(dr.GetOrdinal("TransDate")),
                                Amount = dr.GetDecimal(dr.GetOrdinal("Amount")),
                                Description = dr.GetString(dr.GetOrdinal("Description")),
                                TransactionCode = dr.GetString(dr.GetOrdinal("TranCode")),
                                UnitID = dr.GetInt32(dr.GetOrdinal("UnitID")),
                                RentalDate = dr.GetSmartDate(dr.GetOrdinal("RentalDate"))
                            };
                            mytransactionDTOs.Add(myTransactionDTO);
                        }
                }
               
                return mytransactionDTOs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return null;
            }
            finally
            {
                _myAccessConn.Close();
            }


        }

        private void LoadStorageUnits()
        {
          try
            {
                using (var myAccessCommand = new OleDbCommand(MMSQLGetStorageUnits, _myAccessConn))
                {
                    // _myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            var myStorageUnitDTO = new StorageUnitDTO
                            {
                                AccountID = dr.GetInt32(dr.GetOrdinal(("CustomerID"))),
                                FacilityName = dr.GetString(dr.GetOrdinal("FacilityName")),
                                BuildingNumber = dr.GetString(dr.GetOrdinal("BldgNumber")),
                                UnitNumber = dr.GetString(dr.GetOrdinal("UnitNumber")),
                                UnitRate = dr.GetDecimal(dr.GetOrdinal("UnitRate")),
                                UnitStatus = dr.GetString(dr.GetOrdinal("UnitStatus")),
                                UnitSize = dr.GetString(dr.GetOrdinal("UnitSize"))
                            };
                            mystorageUnitDTOs.Add(myStorageUnitDTO);
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
            }
        }

        private void MergeStorageUnits()
        {
            foreach (var myaccountDtO in myaccountDTOs)
            {
                var o = myaccountDtO;
                var result = from units in mystorageUnitDTOs
                             where units.AccountID == o.AccountID
                             select units;
                myaccountDtO.StorageUnits = result.ToArray();
            }
        }
        
        private void LoadContactItems()
        {
            try
            {
                using (var myAccessCommand = new OleDbCommand(MMSQLGetContactItems, _myAccessConn))
                {
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            var myContactItemDTO = new ContactItemDTO()
                                                        {
                                                            AccountID = dr.GetInt32(dr.GetOrdinal(("CustomerID"))),
                                                            ContactItemID = dr.GetInt32(dr.GetOrdinal("PhoneID")),
                                                            ContactItem = dr.GetString(dr.GetOrdinal("PhoneNumber")),
                                                            Caption = dr.GetString(dr.GetOrdinal("Caption"))
                                                        };
                            myContactItemDTOs.Add(myContactItemDTO);
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
            }
            finally
            {
                _myAccessConn.Close();
            }
        }

        private void MergeContactItems()
        {
            foreach (var myaccountDtO in myaccountDTOs)
            {
                var o = myaccountDtO;
                var result = from phones in myContactItemDTOs
                             where phones.AccountID == o.AccountID
                             select phones;

                myaccountDtO.ContactItems = result.ToArray();
            }

        }

        public override void Dispose()
       {
          _myAccessConn.Dispose();
       }
        
    }
}

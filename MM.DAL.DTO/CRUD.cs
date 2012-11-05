using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Microsoft.Win32;
using Csla.Data;
using MM.DTO;

namespace MM.DAL.DTO
{
    public class Crud
    {
        public  Crud()
        {
        }

        private List<AccountDTO> myDTOs = new List<AccountDTO>();
  
       public List<AccountDTO> GetData()
        {
          var strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
           
           var installPath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\VB and VBA Program Settings\MiniManager\Settings", "TARGETDIR", null);
            if (installPath != null)
            {
                // Do stuff 
                strAccessConn = strAccessConn + installPath;

            } 

            const string strAccessSelect = "SELECT * FROM tblCustomers";

                      OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return null;
            }

           try
            {

                using (var myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn))
                {
                    myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)

                        while (dr.Read())
                        {
                         
                            var myDTO = new AccountDTO
                                            {
                                                AccountID = dr.GetInt32(dr.GetOrdinal("CustomerID")),
                                                Line1 = dr.GetString(dr.GetOrdinal("Line1")),
                                                Line2 = dr.GetString(dr.GetOrdinal("Line2")),
                                                Line3 = dr.GetString(dr.GetOrdinal("Line3")),
                                                Line4 = dr.GetString(dr.GetOrdinal("Line4")),
                                                Line5 = dr.GetString(dr.GetOrdinal("Line5"))
                                            };

                            this.myDTOs.Add(myDTO);
                        }
                }
               return myDTOs;
           }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return null;
            }
           finally
            {
                myAccessConn.Close();
            }



        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ADOX;
using ADODB;
using Csla.Data;
using DataTypeEnum = ADOX.DataTypeEnum;

namespace MM.DAL.DTO
{
  
    public class MiniManagerJetDB

    {
       private string _cnstr = DatabaseInfo.GetConnectionString();
       private ADODB.Connection _myAccessConn;

        public MiniManagerJetDB()
        {
           

            _myAccessConn = new ADODB.Connection();
            _myAccessConn.ConnectionString = _cnstr;
        }

        public static bool IsDBready()
       {
           var mmData = new DatabaseInfo();
           var currentVersion = mmData.GetDatabaseVersion();
           var verNum  = Convert.ToInt32(currentVersion.Substring(5, 2));
           return verNum > 8;
       }

       public  void UpgradeDatabase()
       {
           var cat = new Catalog();

           try
           {
               _myAccessConn.Open();
               cat.ActiveConnection = _myAccessConn;

               var mytable = new ADOX.Table {Name = "tblCustomerSettings"};
               var myColumn = new ADOX.Column
                                  {
                                      Name = "CustomerSettingID",
                                      Type = DataTypeEnum.adInteger,
                                      ParentCatalog = cat
                                  };
               myColumn.Properties["Autoincrement"].Value = true;

               mytable.Columns.Append(myColumn);
               mytable.Columns.Append("CustomerID", DataTypeEnum.adInteger);
               mytable.Columns.Append("BillingMethodID", DataTypeEnum.adInteger);
               mytable.Columns.Append("MobileCarrierID",DataTypeEnum.adInteger);
               cat.Tables.Append(mytable);

               var mykey = new ADOX.Key
                               {
                                   Name = "PrimaryKey",
                                   Type = KeyTypeEnum.adKeyPrimary,
                                   RelatedTable = "tblCustomerSettings"
                               };
               mykey.Columns.Append("CustomerSettingID");
               cat.Tables["tblCustomerSettings"].Keys.Append(mykey);

               //Add data for new table
               InitializeCustomerSettings(_myAccessConn);
               //Upddate the Database Version
               UpdateDBVersion(_myAccessConn);

              foreach (Table tbl in cat.Tables)
               {
                   var myname = tbl.Name;
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

       private void InitializeCustomerSettings(ADODB.Connection mycn)
       {
           var myInsert =
               @"INSERT INTO tblCustomerSettings
                            ( CustomerID, 
                              BillingMethodID,
                              MobileCarrierID
                            )
                            SELECT 
                            tblCustomers.CustomerID,
                            0 AS bmID,
                            0 AS mcID
                            FROM tblCustomers;";
          
           var myCmd = new ADODB.Command {ActiveConnection = mycn, CommandText = myInsert};
           myCmd.CommandType = CommandTypeEnum.adCmdText;

           object dummy = Type.Missing;
           ADODB.Recordset rs = myCmd.Execute(out dummy, ref dummy,0);


       }

       private void UpdateDBVersion(ADODB.Connection mycn)
       {

           var myUpdate = @"Update tblCaptions Set mdbVersion = '1.01.09'";
           var myCmd = new ADODB.Command { ActiveConnection = mycn, CommandText = myUpdate };
           myCmd.CommandType = CommandTypeEnum.adCmdText;

           object dummy = Type.Missing;
           ADODB.Recordset rs = myCmd.Execute(out dummy, ref dummy, 0);
       }





    }



}



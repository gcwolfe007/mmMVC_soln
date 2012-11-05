using System;
using Microsoft.Win32;
using System.Data.OleDb;
using System.Linq;
using Csla.Data;


namespace MM.DAL.DTO
{
    internal class DatabaseInfo
    {

        private string _cnstr = DatabaseInfo.GetConnectionString();
        private OleDbConnection _myAccessConn;
        private string _mdbVersion =string.Empty;

        internal static string GetConnectionString()
        {
            var strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
            var installPath = (string) Registry.GetValue
                                           (@"HKEY_CURRENT_USER\Software\VB and VBA Program Settings\MiniManager\Settings",
                                            "TARGETDIR", null);

            if (installPath != null)
            {
                strAccessConn = strAccessConn + installPath;
            }

            return strAccessConn;
        }

        internal bool GetConnection(out OleDbConnection myAccessConn)
        {
            myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(_cnstr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return true;
            }
            return false;
        }

        internal OleDbConnection GetConnection()
        {

            _myAccessConn = new OleDbConnection(_cnstr);
            return _myAccessConn;
        }


        public string GetDatabaseVersion()
        {
            var mySQLString = "Select mdbVersion From tblCaptions";
            if (GetConnection(out _myAccessConn)) return null;
            try
            {
                using (var myAccessCommand = new OleDbCommand(mySQLString, _myAccessConn))
                {
                    _myAccessConn.Open();
                    using (var dr = new SafeDataReader(myAccessCommand.ExecuteReader()))
                    using (dr)
                        while (dr.Read())
                        {
                            _mdbVersion = dr.GetString(dr.GetOrdinal("mdbVersion"));
                        }
                }
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
            return _mdbVersion;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ASchoolSystem.Requirements.Helpers
{
    class Databases
    {
        private const string Master = "master";
        private const string EmptyDb = "EmptyDb";
        private const string DummyDb = "DummyDb";
        private static string MasterDbConnectionString { get { return BuildConnectionString(Master); } }
        public static string EmptyDbConnectionString { get { return BuildConnectionString(EmptyDb); } }
        public static string DummyDbConnectionString { get { return BuildConnectionString(DummyDb); } }
        private static bool? _Exist = null;
        public static bool Exist
        {
            get
            {
                if (!_Exist.HasValue)
                    _Exist = TryCreateDatabases();
                return _Exist.Value;
            }
        }
        private static bool TryCreateDatabases()
        {
            return TryCreateDatabase(EmptyDb) && TryCreateDatabase(DummyDb);
        }
        private static bool TryCreateDatabase(String dbName)
        {
            string cmd = String.Format(@"CREATE DATABASE MyDatabase ON PRIMARY (NAME = {0}_Data, FILENAME = ''{1}\{0}Data.mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) LOG ON (NAME = {0}_Log, FILENAME = ''{1}\{0}Log.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)", dbName, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            bool success = false;
            SqlConnection myConn = new SqlConnection(MasterDbConnectionString);
            SqlCommand myCommand = new SqlCommand(cmd, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                success = true;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                    myConn.Close();
            }
            return success;
        }
        private static string BuildConnectionString(string dbName)
        {
            return String.Format(@"Server=.\SQLEXPRESS;Integrated security=SSPI;database=|DataDirectory|\{0};", dbName);
        }
    }
}

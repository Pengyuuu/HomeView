using System;
using System.Data;
using System.Data.SqlClient;
using Unite.HomeView.Logging;

namespace Logging.Logging
{
    class LogDAO
    {
        private static string dbConn;
        public LogDAO()
        {
            dbConn = "";
        }
        public bool storeLog(Log log )
        {
            SqlConnection conn = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand("StoreLog", conn);
            conn.Open();
            command.CommandType = CommandType.StoredProcedure;


            return true;
        }
    }
}

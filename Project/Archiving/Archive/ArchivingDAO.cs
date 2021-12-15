using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Logging.Logging;

namespace Archiving.Archiving
{
    class ArchivingDAO
    {
        private static string dbConn;
        public ArchivingDAO()
        {
            dbConn = "";
        }
        public bool archive()
        {
            SqlConnection conn = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand("ArchiveLog", conn);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@timeStamp", SqlDbType.DateTime).Value = DateTime.UtcNow;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace Logging.Logging
{
    public class LogDAO
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
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@ID", SqlDbType.Int).Value = log.Id;
                command.Parameters.Add("@userOperation", SqlDbType.NVarChar).Value = log.UserOperation;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = log.Description;
                command.Parameters.Add("@logLevel", SqlDbType.NVarChar).Value = log.Level;
                command.Parameters.Add("@logCategory", SqlDbType.NVarChar).Value = log.Category;
                command.Parameters.Add("@timeStamp", SqlDbType.DateTime).Value = log.timeStamp;
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

        public bool getLog(int id)
        {
            SqlConnection conn = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand("GetLog", conn);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
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

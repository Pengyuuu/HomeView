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

        public DataRow oldLog()
        {
            SqlConnection conn = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand("GetOldLog", conn);

            try
            {   // connects to sql
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@timeStamp", SqlDbType.DateTime).Value = DateTime.UtcNow;
                SqlDataReader read = command.ExecuteReader();

                //command.ExecuteNonQuery();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        
                    }
                }
                else
                {
                    result = "No record found.";
                }
                read.Close();

            }
            catch (SqlException e)
            {
                // unable to enable user record
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                result = "Unable to get user id: " + id;
            }

            finally
            {
                // closes sql connection
                connection.Close();
            }

            return result;
        }
    }
}

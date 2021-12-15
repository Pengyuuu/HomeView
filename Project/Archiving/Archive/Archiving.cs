using System;
using System.Data;
using System.Data.SqlClient;

namespace Archive
{
    public class Archiving
    {
        private static Archiving instance = null;
        private static string dbConn;

        public Archiving()
        {
            dbConn = "";
        }

        // Singleton design pattern, makes sure there's only one archiving
        public static Archiving GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new Archiving();
                }

                return instance;
            }
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

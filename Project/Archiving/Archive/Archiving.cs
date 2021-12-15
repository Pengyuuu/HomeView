using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archive
{
    public class Archiving
    {
        private static Archiving instance = null;
        private static string dbConn;
        private List<string> log = new List<string>();

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

        public List<string> oldLog()
        {
            SqlConnection conn = new SqlConnection(dbConn);
            SqlCommand command = new SqlCommand("GetOldLog", conn);
            string result = "";
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
                        result = read.GetInt32(0).ToString() + " " + read.GetString(1).ToString() + " " +
                                read.GetString(2).ToString() + " " + read.GetString(3).ToString() + " " +
                                read.GetString(4).ToString();
                        log.Add(result);
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
                conn.Close();
            }

            return log;
        }
    }
}

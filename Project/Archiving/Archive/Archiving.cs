using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archive
{
    public class Archiving
    {
        private static Archiving instance = null;
        private List<string> log = new List<string>();

        public Archiving()
        {
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
            SqlConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString());
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
                                read.GetString(4).ToString() + read.GetString(5).ToString(); 
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
                conn.Close();
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

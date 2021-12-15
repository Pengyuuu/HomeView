using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Archiving.Archiving;

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

        public bool oldLog()
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

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        // reads each log, appends each column into a single string, and adds it to the list
                        result = read.GetInt32(0).ToString() + " " + read.GetString(1).ToString() + " " +
                                read.GetString(2).ToString() + " " + read.GetString(3).ToString() + " " +
                                read.GetString(4).ToString() + read.GetString(5).ToString(); 
                        log.Add(result);
                    }
                }
                else
                {
                    // No log fits the criteria for archiving
                    result = "No record found.";
                }

                // Close SQLReader
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

            // Create archiving manager and send it the logs
            ArchivingManager archiveManager = ArchivingManager.GetInstance;

            archiveManager.compress(log);

            return true;
        }
    }
}

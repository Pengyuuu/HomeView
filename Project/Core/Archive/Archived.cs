using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Core.Archive
{
    public class Archived
    {
        private static Archived _instance = null;
        private List<string> _log = new List<string>();

       
        public Archived()
        {
        }
        

        // Singleton design pattern, makes sure there's only one archiving
        public static Archived GetInstance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new Archived();
                }

                return _instance;
            }
        }

        /**
         * Grabs 30-day old logs and puts them into a list to be archived
         * @returns true once logs have been archived
         */
        public bool ArchiveLog()
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
                        result = read.GetInt32(0).ToString() + "," + read.GetString(1).ToString() + "," +
                                read.GetString(2).ToString() + "," + read.GetString(3).ToString() + "," +
                                read.GetDateTime(4).ToString(); 
                        _log.Add(result);
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
                Console.WriteLine("Error Generated. Details: " + e.ToString());
            }

            finally
            {
                // closes sql connection
                conn.Close();
            }

            // Create archiving manager and send it the logs
            ArchivingManager archiveManager = ArchivingManager.GetInstance;

            archiveManager.Compress(_log);

            return true;
        }
    }
}

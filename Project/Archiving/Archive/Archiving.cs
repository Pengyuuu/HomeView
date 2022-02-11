using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Archiving.Archiving;

namespace Archive
{
    public class Archiving
    {
        private static Archiving _instance = null;
        private List<string> _log = new List<string>();

        public Archiving()
        {
        }

        // Singleton design pattern, makes sure there's only one archiving
        public static Archiving GetInstance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new Archiving();
                }

                return _instance;
            }
        }

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
                        result = read.GetInt32(0).ToString() + " " + read.GetString(1).ToString() + " " +
                                read.GetString(2).ToString() + " " + read.GetString(3).ToString() + " " +
                                read.GetString(4).ToString() + read.GetString(5).ToString(); 
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
                // unable to enable user record
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

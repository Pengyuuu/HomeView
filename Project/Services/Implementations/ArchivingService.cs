using System.Collections.Generic;
using Core.Archive;
using System;
using System.Data;
using System.Data.SqlClient;
using Services.Contracts;

namespace Services.Implementations
{
    public class ArchivingService : IArchivingService
    {
        //private static ArchivingService _instance = null;
        private List<string> _log = new List<string>();

        /**
        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingService GetInstance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new ArchivingService();
                }

                return _instance;
            }
        }**/
        public ArchivingService()
        {

        }

        public bool SendLogs(List<string> oldLogs)
        {
            // Create archiving DAO and send it the logs
            ArchivingDAO archive = ArchivingDAO.GetInstance;

            archive.Send(oldLogs);

            return true;
        }

        /**
         * Grabs 30-day old logs and puts them into a list to be archived
         * @returns true once logs have been archived
         
        public bool ArchiveLog()
        {
            SqlConnection conn = new SqlConnection(getConnectionString());
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
            SendLogs(_log);

            return true;
        }**/
    }
}

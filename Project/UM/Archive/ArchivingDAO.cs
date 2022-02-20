using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Logging.Logging;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Archiving.Archive
{
    class ArchivingDAO
    {
        private static ArchivingDAO _instance;
        private static string _filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Archives.csv");
        private static string _zipPath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Archives.zip");

        public static ArchivingDAO GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ArchivingDAO();
                }

                return _instance;
            }
        }
        public ArchivingDAO()
        {
            
        }

        /**
         * Writes all 30-day old logs into the csv file
         * @param oldLogs - a list of all logs that are 30-days old
         * @return true if successfully writes old logs to csv file
         */
        public bool Send(List<string> oldLogs)
        {

            var csv = new StringBuilder();

            // Iterate through the list of old logs and append it line by line to the csv variable
            for (int i = 0; i < oldLogs.Count; i++)
            {
                csv.AppendLine(oldLogs[i].ToString());
            }

            // If csv file already exists, append the logs to the file
            if (File.Exists(_filePath)) 
            { 
                File.AppendAllText(_filePath, csv.ToString());

                ZipFile.CreateFromDirectory(_filePath, _zipPath);
            }

            // Writes the archived logs and exports as a csv file
            else 
            { 
                File.WriteAllText(_filePath, csv.ToString()); 
            }

            return true;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Logging.Logging;
using System.Text;
using System.IO;

namespace Archiving.Archive
{
    class ArchivingDAO
    {
        private static ArchivingDAO _instance;
        private static string _filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Archives.csv");

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

        public bool Send(List<string> oldLogs)
        {

            var csv = new StringBuilder();

            // Iterate through the list of old logs and append it line by line to the csv variable
            for (int i = 0; i < oldLogs.Count; i++)
            {
                csv.AppendLine(oldLogs[i].ToString());
            }

            // Writes the archived logs and exports as a csv file
            File.WriteAllText(_filePath, csv.ToString());

            return true;
        }
    }
}

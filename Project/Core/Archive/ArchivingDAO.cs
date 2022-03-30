using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Core.Archive
{
    public class ArchivingDAO
    {
        private static ArchivingDAO _instance;
        private string _filePath;
        private string _zipPath;

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
            _filePath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Archives.csv");
            _zipPath = Path.GetFullPath("@\\..\\..\\..\\..\\..\\..\\Project\\Data\\Archives.zip");
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

                using (var zipArchive = ZipFile.Open(_zipPath, ZipArchiveMode.Update))
                {
                        var fileInfo = new FileInfo(_filePath);
                        zipArchive.CreateEntryFromFile(fileInfo.FullName, fileInfo.Name);
                }

                //ZipFile.CreateFromDirectory(_filePath, _zipPath);
            }

            // Writes the archived logs and exports as a csv file
            else 
            { 
                File.WriteAllText(_filePath, csv.ToString());
                using (var archive = ZipFile.Open(_zipPath, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(_filePath, Path.GetFileName(_filePath));
                }
            }

            return true;
        }
    }
}

using System.Collections.Generic;

namespace Archiving.Archiving
{
    public class ArchivingService
    {
        private static ArchivingService instance = null;

        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingService GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ArchivingService();
                }

                return instance;
            }
        }

        public bool sendLogs(List<string> oldLogs)
        {
            // Create archiving DAO and send it the logs
            ArchivingDAO archive = ArchivingDAO.GetInstance;

            archive.send(oldLogs);

            return true;
        }
    }
}

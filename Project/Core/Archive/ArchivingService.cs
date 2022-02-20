using System.Collections.Generic;

namespace Archive
{
    public class ArchivingService
    {
        private static ArchivingService _instance = null;

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
        }

        public bool SendLogs(List<string> oldLogs)
        {
            // Create archiving DAO and send it the logs
            ArchivingDAO archive = ArchivingDAO.GetInstance;

            archive.Send(oldLogs);

            return true;
        }
    }
}

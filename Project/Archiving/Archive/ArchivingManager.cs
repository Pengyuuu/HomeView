using System.Collections.Generic;

namespace Archiving.Archiving
{
    public class ArchivingManager
    {
        private static ArchivingManager instance = null;

        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingManager GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ArchivingManager();
                }

                return instance;
            }
        }

        public bool compress(List<string> oldLogs)
        {
            // Create archiving service and send it the logs
            ArchivingService archiveService = ArchivingService.GetInstance;

            archiveService.sendLogs(oldLogs);

            return true;
        }
    }
}

using System.Collections.Generic;
using Core.Archive;
using Managers.Contracts;
using Services.Contracts;

namespace Managers.Implementations
{
    public class ArchivingManager : IArchivingManager
    {
        private IArchivingService _service;
        //private ArchivingManager _instance = null;

        /**
        // Singleton design pattern, makes sure there's only one archiving
        public static ArchivingManager GetInstance
        {

            get
            {
                if (_instance == null)
                {
                    _instance = new ArchivingManager();
                }

                return _instance;
            }
        }**/

        public bool Compress(List<string> oldLogs)
        {
            // Create archiving service and send it the logs
            return _service.SendLogs(oldLogs);

        }
    }
}

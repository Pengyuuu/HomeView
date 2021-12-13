using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unite.HomeView.Logging;

namespace Logging.Logging
{
    class LoggingManager
    {
        private Log log;
        private static LoggingManager instance = null;
        public static LoggingManager GetInstance
        {

            get
            {
                if (GetInstance == null)
                {
                    instance = new LoggingManager();
                }

                return instance;
            }
        }

        private LoggingManager()
        {

        }
        // Method to create log 
        public void Log(int id, string userop, string desc, LogLevel level, LogCategory category, DateTime timestamp)
        {
            log.Id = id;
            log.UserOperation = userop;
            log.Description = desc;
            log.Level = level;
            log.Category = category;
            log.Timestamp = timestamp;
        }

        // Manager communicates with Service layer through this method
        public void Info(int id, string userop, string desc, LogLevel level, LogCategory category, DateTime timestamp)
        {
            // Create new logging service here
            LoggingService logService = LoggingService.GetInstance;

            // Call a logging service function to send in the log file
            logService.Create(log);
        }
    }
}

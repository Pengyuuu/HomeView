using System;

namespace Logging.Logging
{
    public class LoggingManager
    {
        public LoggingManager()
        {

        }


        // Manager communicates with Service layer through this method
        public bool logData(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            // Create new logging service here
            LoggingService logService = new LoggingService();

            Log log = new Log();

            log.Description = desc;
            log.Level = level;
            log.Category = category;
            log.timeStamp = timeStamp;

            // Call a logging service function to send in the log file
            if (logService.Create(log))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool logData(Log log)
        {
            LoggingService logService = new LoggingService();

            if (logService.Create(log))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Log getLog(int id)
       {
            LoggingService logService = new LoggingService();

            Log retrievedLog = logService.getLog(id);

            return retrievedLog;
        }
    }
}

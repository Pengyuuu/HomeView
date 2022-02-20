using System;

namespace Logging.Logging
{
    public class LoggingManager
    {
        public LoggingManager()
        {

        }


        // Manager communicates with Service layer through this method
        public bool LogData(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            // Create new logging service here
            LoggingService logService = new LoggingService();

            Log log = new Log(desc, level, category, timeStamp);

            /*
            log.Description = desc;
            log.Level = level;
            log.Category = category;
            log.timeStamp = timeStamp;
            */

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

        public bool LogData(Log log)
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

        public Log GetLog(int id)
       {
            LoggingService logService = new LoggingService();

            Log retrievedLog = logService.GetLog(id);

            return retrievedLog;
        }
    }
}

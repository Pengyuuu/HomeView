using System;

namespace Logging
{
    public class LoggingManager
    {
        public LoggingManager()
        {

        }


        // Manager communicates with Service layer through this method
        public bool LogData(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            throw new NotImplementedException();
        }

        public bool LogData(Log log)
        {
            /*LoggingService logService = new LoggingService();

            if (logService.Create(log))
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return false;
        }

        public Log GetLog(int id)
       {
            throw new NotImplementedException();
        }
    }
}

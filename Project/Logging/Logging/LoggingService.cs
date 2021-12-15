using System;

namespace Logging.Logging
{
    public class LoggingService : ILogService
    {
        // Creates a log object
        //private Log log;


        // A logging service has not been initialized yet, so set to null
        /* private static LoggingService instance = null;

        // Singleton design pattern, makes sure there's only one logging service
        public static LoggingService GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new LoggingService();
                }
                Console.WriteLine(instance);
                return instance;
            }
        }
        */
        public LoggingService()
        {

        }

        // Method to create log 
        public bool Log(int id, LogUserOperation userOp, string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            Log log = new Log();

            log.Id = id;
            log.UserOperation = userOp;
            log.Description = desc;
            log.Level = level;
            log.Category = category;
            log.timeStamp = timeStamp;
            return true;
        }

        // This method should send the log to the data access object
        public bool Create(Log logFile)
        {
            LogDAO dAccess = new LogDAO();
            if (dAccess.storeLog(logFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

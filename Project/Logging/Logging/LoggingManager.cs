using System;

namespace Logging.Logging
{
    public class LoggingManager
    {

        public Log log;
        /*
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
        */
        public LoggingManager()
        {

        }


        // Manager communicates with Service layer through this method
        public bool Info(int id, LogUserOperation userOp, string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            Console.WriteLine("IIIIIIIASDFASDIIIIIIII");
            // Create new logging service here
            LoggingService logService = LoggingService.GetInstance;

            Console.WriteLine(logService + "test");

            Log log = new Log();

            log.Id = id;
            log.UserOperation = userOp;
            log.Description = desc;
            log.Level = level;
            log.Category = category;
            log.timeStamp = timeStamp;

            // Call a logging service function to send in the log file
            logService.Create(log);
            return true;
        }
    }
}

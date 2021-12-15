using System;

namespace Logging.Logging
{
    public class LoggingService
    {
        // Creates a log object
        //private Log log;


        // A logging service has not been initialized yet, so set to null
        private static LoggingService instance = null;

        // Singleton design pattern, makes sure there's only one logging service
        private static LoggingService GetInstance
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

using System;

namespace Logging.Logging
{
    public class LoggingService
    {
        private static LoggingService instance = null;

        // Singleton design pattern, makes sure there's only one logging service
        public static LoggingService GetInstance
        {

            get
            {
                if (instance == null)
                {
                    instance = new LoggingService();
                }

                return instance;
            }
        }

        // This method should send the log to the data access object
        public bool Create(Log logFile)
        {
            LogDAO dAccess = new LogDAO(this);

            if (dAccess.storeLog(logFile))
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
            LogDAO dao = new(this);
            Log log = dao.getLog(id);
            return log;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unite.HomeView.Contracts;
using Unite.HomeView.Logging;

namespace Unite.HomeView.Logging
{
    class LoggingService : ILogService
    {
        // Creates a log object
        private Log log;
        // A logging service has not been initialized yet, so set to null
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

        // Constructor for logging service
        private LoggingService()
        {
            // Probably set up database connections in here
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

        // This method should send the log to the data access object
        public void Create(Log logFile)
        {

        }
    }
}

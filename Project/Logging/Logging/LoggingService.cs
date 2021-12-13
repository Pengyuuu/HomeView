using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Log(int id, string desc, string mycol, string timestamp)
        {
            log.Id = id;
            log.Description = desc;
            log.Mycol = mycol;
            log.Timestamp = timestamp;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logging
{
    public class LoggingManager
    {
        private LogDAO _logDAO;

        public LoggingManager()
        {
            _logDAO = new LogDAO(new Data.SqlDataAccess());
        }


        // Manager communicates with Service layer through this method
        public Task LogData(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            Log log = new Log(desc, level, category, timeStamp);

            // Call a logging service function to send in the log file
            return _logDAO.StoreLog(log);
        }

        public Task LogData(Log log)
        {
            return _logDAO.StoreLog(log);
        }

        public Task<IEnumerable<Log>> GetLog(int id)
       {
            return _logDAO.GetLog(id);
        }
    }
}

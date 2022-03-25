using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Contracts;
using Core.Logging;
using Services.Contracts;


namespace Managers.Implementations
{
    public class LoggingManager : ILoggingManager
    {
        private ILoggingService _loggingService;
        public LoggingManager()
        {

        }

        // Manager communicates with Service layer through this method
        public Task LogData(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            return _loggingService.LogData(desc, level, category, timeStamp);
        }

        public Task LogData(Log log)
        {
            return _loggingService.LogData(log);
        }

        public Log GetLog(int id)
        {
            return _loggingService.GetLog(id);
        }

        public Task<IEnumerable<Log>> GetLog(DateTime timeStamp)
        {
            return _loggingService.GetLog(timeStamp);
        }

        public bool DeleteOldLog()
        {
            return _loggingService.DeleteOldLog();
        }



    }
}

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
        public async Task<bool> LogDataAsync(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            return await _loggingService.LogDataAsync(desc, level, category, timeStamp);
        }

        public async Task<bool> LogDataAsync(Log log)
        {
            return await _loggingService.LogDataAsync(log);
        }

        public Log GetLog(int id)
        {
            return _loggingService.GetLog(id);
        }

        public async Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp)
        {
            return await _loggingService.GetLogAsync(timeStamp);
        }

        public bool DeleteOldLog()
        {
            return _loggingService.DeleteOldLog();
        }



    }
}

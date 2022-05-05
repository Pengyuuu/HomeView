using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Contracts;
using Core.Logging;
using Services.Contracts;
using Services.Implementations;


namespace Managers.Implementations
{
    public class LoggingManager : ILoggingManager
    {
        private ILoggingService _loggingService;
        public LoggingManager()
        {
            _loggingService = new LoggingService();
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

        public async Task<IEnumerable<Log>> GetLogAsync(int id)
        {
            return await _loggingService.GetLogAsync(id);
        }

        public async Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp)
        {
            return await _loggingService.GetLogAsync(timeStamp);
        }

        public async Task<bool> DeleteOldLogAsync()
        {
            return await _loggingService.DeleteOldLogAsync();
        }



    }
}

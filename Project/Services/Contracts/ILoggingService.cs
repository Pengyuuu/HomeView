using Core.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggingService
    {
        Task<bool> DeleteOldLogAsync();
        Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp);
        Task<IEnumerable<Log>> GetLogAsync(int id);
        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<bool> LogDataAsync(Log log);
        Task<bool> LogDataAsync(string desc, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
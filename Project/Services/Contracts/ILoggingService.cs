using Core.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggingService
    {
        bool DeleteOldLog();
        Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp);
        Log GetLog(int id);
        Task<bool> LogDataAsync(Log log);
        Task<bool> LogDataAsync(string desc, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
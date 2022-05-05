using Core.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface ILoggingManager
    {
        Task<bool> DeleteOldLogAsync();

        Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp);

        Task<IEnumerable<Log>> GetLogAsync(int id);

        Task<bool> LogDataAsync(Log log);

        Task<bool> LogDataAsync(string desc, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
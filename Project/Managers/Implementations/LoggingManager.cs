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

        public async Task<bool> LogDataAsync(int viewId, string token)
        {
            Log viewAccessed = new Log();
            viewAccessed.Level = 0;
            viewAccessed.Category = 0;
            viewAccessed.timeStamp = DateTime.Now;
            if (viewId == 1)
            {
                viewAccessed.Description = "Account View accessed." + ":" + token;
            }
            else if (viewId == 2)
            {
                viewAccessed.Description = "Home Page View accessed." + ":" + token;
            }
            else if (viewId == 3)
            {
                viewAccessed.Description = "Movies View accessed." + ":" + token;
            }
            else if (viewId == 4)
            {
                viewAccessed.Description = "TV Shows View accessed." + ":" + token;
            }
            else if (viewId == 5)
            {
                viewAccessed.Description = "ActWiki View accessed." + ":" + token;
            }
            else if (viewId == 6)
            {
                viewAccessed.Description = "Streaming Services View accessed." + ":" + token;
            }
            else if (viewId == 7)
            {
                viewAccessed.Description = "News View accessed." + ":" + token;
            }
            return await _loggingService.LogDataAsync(viewAccessed);
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

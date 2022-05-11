using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Logging;
using Data;
using Services.Contracts;

namespace Services.Implementations
{
    public class LoggingService : ILoggingService
    {
        private LogDAO _logDAO;
        public LoggingService()
        {
            _logDAO = new LogDAO();
        }

        // Manager communicates with Service layer through this method
        public async Task<bool> LogDataAsync(string desc, LogLevel level, LogCategory category, DateTime timeStamp)
        {
            Log log = new Log(desc, level, category, timeStamp);

            // Call a logging service function to send in the log file
            var result = await _logDAO.StoreLogAsync(log);

            // If more than one row was inserted, then logging was not done correctly
            if (result != 1)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> LogDataAsync(Log log)
        {
            var result = await _logDAO.StoreLogAsync(log);

            if (result != 1)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Log>> GetLogAsync(int id)
        {
            return await _logDAO.GetLogAsync(id);
        }

        public async Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp)
        {
            return await _logDAO.GetLogsAsync(timeStamp);
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync()
        {
            return await _logDAO.GetAllLogsAsync();
        }

        public async Task<IEnumerable<Log>> GetCategoryLogsAsync(int category)
        {
            return await _logDAO.GetCategoryLogAsync(category);
        }
       
        public async Task<bool> DeleteOldLogAsync()
        {

            await _logDAO.DeleteOldLogsAsync();

            return true;
        }
    }
}

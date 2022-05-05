﻿using System;
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

        public Log GetLog(int id)
        {
            return (Log)_logDAO.GetLog(id).Result;
        }

        public async Task<IEnumerable<Log>> GetLogAsync(DateTime timeStamp)
        {
            return await _logDAO.GetLogsAsync(timeStamp);
        }

        public bool DeleteOldLog()
        {

            _logDAO.DeleteOldLogs();

            return true;
            /*
            if (_logDAO.DeleteOldLogs() is not null)
            {

                return true;
            }
            else
            {
                return false;
            }*/
        }
    }
}

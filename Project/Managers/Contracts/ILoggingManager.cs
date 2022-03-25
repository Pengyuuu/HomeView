﻿using Core.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Contracts
{
    public interface ILoggingManager
    {
        bool DeleteOldLog();
        Task<IEnumerable<Log>> GetLog(DateTime timeStamp);
        Log GetLog(int id);
        Task LogData(Log log);
        Task LogData(string desc, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
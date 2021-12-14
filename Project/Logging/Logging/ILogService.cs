using Logging.Logging;
using System;

namespace Unite.HomeView.Logging
{
    public interface ILogService
    {
        bool Log(int id, LogUserOperation userOp, string description, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
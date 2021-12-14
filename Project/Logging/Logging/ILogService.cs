using System;

namespace Logging.Logging
{
    public interface ILogService
    {
        bool Log(int id, LogUserOperation userOp, string description, LogLevel level, LogCategory category, DateTime timeStamp);
    }
}
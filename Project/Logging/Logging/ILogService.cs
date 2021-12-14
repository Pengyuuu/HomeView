using System;

namespace Unite.HomeView.Contracts
{
    public interface ILogService
    {
        bool Log(int id, string userop, string description, LogLevel level, string timeStamp);
    }
}
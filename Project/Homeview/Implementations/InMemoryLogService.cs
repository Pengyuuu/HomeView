using System;
using System.Collections.Generic;

namespace Unite.HomeView.Implementations
{
    public class InMemoryLogService : Contracts.ILogService
    {
        private readonly IList<string> logStore;

        public InMemoryLogService()
        {
            logStore = new List<string>();
        }
        public bool Log(int id, string description, string myCol, string timeStamp)
        {
            try
            {
                logStore.Add($"{DateTime.UtcNow}->{description}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public IList<string> getLogs()
        {
            return logStore;
        }
    }
}
    
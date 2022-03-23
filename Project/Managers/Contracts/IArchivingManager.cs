using System.Collections.Generic;

namespace Managers.Contracts
{
    public interface IArchivingManager
    {
        bool Compress(List<string> oldLogs);
    }
}
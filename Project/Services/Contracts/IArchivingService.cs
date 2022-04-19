using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IArchivingService
    {
        //bool ArchiveLog();
        bool SendLogs(List<string> oldLogs);
    }
}
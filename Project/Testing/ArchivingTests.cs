using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Archive;
using Logging.Logging;

namespace Testing
{
    public class ArchivingTests
    {
        [Fact]
        public void Archiving_ArchivingOldLogShouldLogLogsOlderThan30Days()
        {
            Boolean expected = true;

            Log testLog = new("ArchivingTests - Log", LogLevel.Info, LogCategory.Data, new DateTime(2020, 10, 10));
            LoggingManager logManager = new LoggingManager();
            logManager.logData(testLog);

            Archive.Archiving archivingTest = new Archive.Archiving();
            Boolean actual = archivingTest.oldLog();

            Assert.Equal(expected, actual);

        }
    }
}

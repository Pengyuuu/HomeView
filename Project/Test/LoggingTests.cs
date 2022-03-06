using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Logging;

namespace LoggingTests
{
    public class LoggingTests

    {

        private Log testLog = new("5:40 New Test log", LogLevel.Info, LogCategory.Data, DateTime.UtcNow);

        [Fact]
        public void LoggingManager_getLogShouldReturnLogFromTable()
        {
            // arrange
            Log actual = testLog;

            //act
            LoggingManager logManager = new LoggingManager();
            logManager.LogData(testLog);
            actual = (Log) logManager.GetLog(384);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            Boolean expected = true;

            Boolean want = true;

            LoggingManager lm = new LoggingManager();

            lm.LogData(testLog);

            var retrievedLog = lm.GetLog(testLog.timeStamp).Result;

            var result = testLog.timeStamp;

            foreach (var log in retrievedLog)
            {
                if (log.timeStamp != result)
                {
                    want = false;
                    break;
                }
            }

            Assert.Equal(expected, want);
        }

        [Fact]
        public void LoggingDAO_DeleteOldLogsShouldDeleteMonthOldLogs()
        {

        }
    }
}

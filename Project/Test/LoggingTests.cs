using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core.Logging;
using Managers.Contracts;

namespace LoggingTests
{
    public class LoggingTests

    {

        private Log testLog = new("5:40 New Test log", LogLevel.Info, LogCategory.Data, DateTime.UtcNow);
        private ILoggingManager logManager;

        [Fact]
        public void LoggingManager_getLogShouldReturnLogFromTable()
        {
            // arrange
            Log actual = testLog;

            //act
            logManager.LogDataAsync(testLog);
            actual = (Log) logManager.GetLog(384);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            bool expected = true;

            bool actual = true;

            logManager.LogDataAsync(testLog);

            var retrievedLog = logManager.GetLogAsync(testLog.timeStamp).Result;

            foreach (var log in retrievedLog)
            {
                if (log.timeStamp != testLog.timeStamp)
                {
                    actual = false;
                    break;
                }
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoggingDAO_DeleteOldLogsShouldDeleteMonthOldLogs()
        {

            bool expected = true;

            bool actual = logManager.DeleteOldLog();

            Assert.Equal(expected, actual);
        }
    }
}

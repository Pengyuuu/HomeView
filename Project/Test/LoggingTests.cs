using System;
using Xunit;
using Core.Logging;
using Managers.Contracts;
using Managers.Implementations;

namespace LoggingTests
{
    public class LoggingTests

    {
        private Log testLog = new Log("5:40 New Test log", LogLevel.Info, LogCategory.Data, DateTime.UtcNow);

        ILoggingManager logManager = new LoggingManager();

        [Fact]
        public void LoggingManager_getLogShouldReturnLogFromTable()
        {
            // arrange
            Log actual = testLog;

            //act
            logManager.LogDataAsync(testLog);
            var result = logManager.GetLogAsync(384).Result;

            //assert
            Assert.NotNull(result);
        }

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            bool expected = true;

            bool actual = true;

            var result = logManager.LogDataAsync(testLog);

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

            bool actual = logManager.DeleteOldLogAsync().Result;

            Assert.Equal(expected, actual);
        }
    }
}

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

        private Log testLog = new("6:40 New Test log", LogLevel.Info, LogCategory.Data, DateTime.UtcNow);

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
            bool expected = true;

            LoggingManager lm = new LoggingManager();
            lm.LogData(testLog);

            // (actual
            //sert.Equal(expected, actual);
        }

        //[Fact]
        //public void LoggingDAO_
    }
}

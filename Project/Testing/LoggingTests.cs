using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Logging;

namespace Testing.LoggingTests
{
    public class LoggingTests

    {

        private static Log testLog = new("Test log", LogLevel.Info, LogCategory.Data, new DateTime(2021, 12, 15));

        [Fact]
        public void LoggingManager_getLogShouldReturnLogFromTable()
        {
            // arrange
            Log actual;

            //act
            LoggingManager logManager = new LoggingManager();
            logManager.LogData(testLog);
            actual = logManager.GetLog(1);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            bool expected = true;

            LoggingManager lm = new();
            bool actual = lm.LogData(testLog);

            Assert.Equal(expected, actual);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Logging.Logging;

namespace Testing.LoggingTests
{
    public class LoggingTests

    {

        private static Log testLog = new(LogUserOperation.Create, "Test log", LogLevel.Info, LogCategory.Data, new DateTime(2021, 12, 15));

        [Fact]
        public void LoggingManager_getLogShouldReturnLogFromTable()
        {
            // arrange
            Log actual;

            //act
            LoggingManager logManager = new LoggingManager();
            logManager.logData(testLog);
            actual = logManager.getLog(1);

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            bool expected = true;

            LoggingManager lm = new();
            bool actual = lm.logData(testLog);

            Assert.Equal(expected, actual);

        }

    }
}

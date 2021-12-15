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

        private static Log testLog = new(7357, LogUserOperation.Create, "Test log", LogLevel.Info, LogCategory.Data, new DateTime(2021, 12, 15));

        [Fact]
        public void LoggingManager_logDataShouldCreateLoggingTableEntry()
        {
            // arrange
            Log actual;

            //act
            LoggingManager logManager = new LoggingManager();
            logManager.logData(testLog);
            actual = logManager.getLog(testLog.Id);

            //assert
            Assert.Equal(testLog.Id, actual.Id);
            Assert.Equal(testLog.UserOperation, actual.UserOperation);
            Assert.Equal(testLog.Description, actual.Description);
            Assert.Equal(testLog.Level, actual.Level);
            Assert.Equal(testLog.Category, actual.Category);
            Assert.Equal(testLog.timeStamp, actual.timeStamp);
        }

    }
}

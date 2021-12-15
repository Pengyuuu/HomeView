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
        //Logging.Logging.LogUserOperation = Logging.Logging.LogUserOperation Create
        private static System.DateTime actualDate = new DateTime(2020, 8, 11);

        [Fact]
        public void LoggingManager_InfoShouldCreateLoggingServiceAndSendLogFile()
        {
            Boolean expected = true;

            LoggingManager logManager = LoggingManager.GetInstance;
            Boolean actual = logManager.Info(102, LogUserOperation.Create, "Test Log - LoggingManager Info()", LogLevel.Info, LogCategory.View, actualDate);

            Assert.Equal(expected, actual);
        }

        // Tests LogDAO.storeLog() too 
        // manager.info -> service.create -> logdao.storelog
        [Fact]
        public void LoggingService_LogShouldCreateLog()
        {
            Boolean expected = true;

            LoggingService logService = LoggingService.GetInstance;
            Boolean actual = logService.Log(103, LogUserOperation.Create, "Test Log - LoggingService Log()", LogLevel.Info, LogCategory.View, actualDate);

            Assert.Equal(expected, actual);

        }

        // Have to access database to check
        // Tests LogDAO.getLog() too
        [Fact]
        public void LoggingService_CreateShouldSendLogToDAO()
        {
            Boolean expected = true;

            LoggingManager logManager = LoggingManager.GetInstance;
            // Log created
            logManager.Info(104, LogUserOperation.Create, "Test Log - LoggingService Create()", LogLevel.Info, LogCategory.View, actualDate);

            // Access db
            LogDAO dAccess = new LogDAO();
            // Check if log 104 exists
            Boolean actual = dAccess.getLog(104);

            Assert.Equal(expected, actual);

        }
    }
}

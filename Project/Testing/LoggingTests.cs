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
        
        private Log actualLog = new Log(1, LogUserOperation.Create, "Test Log", LogLevel.Info, LogCategory.View, actualDate);

        /*
        public void Log_GetIDShouldGetID()
        {
            int expected = 1;

            int actual = actualLog.getId();

            Assert.Equal(expected, actual);
        }

        public void Log_SetIDShouldSetID()
        {
            int expected = 2;

            actualLog.setId(2);

            int actual = actualLog.getId();

            Assert.Equal(expected, actual);

            // actualLog.setId(1);
        }

        public void Log_GetUserOperationShouldGetUserOperation()
        {
            LogUserOperation expected = LogUserOperation.Create;

            LogUserOperation actual = actualLog.getLogUserOperation();

            Assert.Equal(expected, actual);
        }

        public void Log_SetUserOperationShouldSetUserOperation()
        {
            LogUserOperation expected = LogUserOperation.Update;

            actualLog.setLogUserOperation(LogUserOperation.Update);

            LogUserOperation actual = actualLog.getLogUserOperation();

            Assert.Equal(expected, actual);
        }

        public void Log_GetDecriptionShouldGetDescription()
        {
            string expected = "Test Log";

            string actual = actualLog.getDescription();

            Assert.Equal(expected, actual);
        }

        public void Log_SetDescriptionShouldSetDescription()
        {
            string expected = "Changed Test Log";

            actualLog.setDescription("Changed Test Log");

            string actual = actualLog.getDescription();

            Assert.Equal(expected, actual);
        }

        public void Log_GetLevelShouldGetLogLevel()
        {
            LogLevel expected = LogLevel.Info;

            LogLevel actual = actualLog.getLevel();

            Assert.Equal(expected, actual);
        }

        public void Log_SetLevelShouldSetLogLevel()
        {
            LogLevel expected = LogLevel.Debug;

            actualLog.setLevel(LogLevel.Debug);

            LogLevel actual = actualLog.getLevel();

            Assert.Equal(expected, actual);
        }

        public void Log_GetCategoryShouldGetLogCategory()
        {
            LogCategory expected = LogCategory.View;

            LogCategory actual = actualLog.getCategory();

            Assert.Equal(expected, actual);
        }

        public void Log_SetCategoryShouldSetLogCategory()
        {
            LogCategory expected = LogCategory.Data;

            actualLog.setCategory(LogCategory.Data);

            LogCategory actual = actualLog.getCategory();

            Assert.Equal(expected, actual);
        }

        public void Log_GetTimeStampShouldGetTimeStamp()
        {
            DateTime expected = new DateTime(2020, 8, 11);

            DateTime actual = actualLog.gettimeStamp();

            Assert.Equal(expected.ToString(), actual.ToString());
        }

        public void Log_SetTimeStampShouldSetTimeStamp()
        {
            DateTime expected = new DateTime(2019, 7, 10);

            DateTime newTime = new DateTime(2019, 7, 10);

            actualLog.settimeStamp(newTime);

            DateTime actual = actualLog.gettimeStamp();

            Assert.Equal(expected.ToString(), actual.ToString());
        }
        */

        [Fact]
        public void LoggingManager_InfoShouldCreateLoggingServiceAndSendLogFile()
        {
            Boolean expected = true;

            LoggingManager logManager = LoggingManager.GetInstance;
            Boolean actual = logManager.Info(102, LogUserOperation.Create, "Test Log - LoggingManager Info()", LogLevel.Info, LogCategory.View, actualDate);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoggingService_LogShouldCreateLog()
        {
            Boolean expected = true;

            LoggingService logService = LoggingService.GetInstance;
            Boolean actual = logService.Log(103, LogUserOperation.Create, "Test Log - LoggingService Log()", LogLevel.Info, LogCategory.View, actualDate);

            Assert.Equal(expected, actual);

        }

        // Have to access database to check
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

        public void LogDAO_storeLogShouldStoreLogToDatabase()
        {

        }

        public void LogDAO_getLogShouldGetLogFromDatabase()
        {

        }
    }
}

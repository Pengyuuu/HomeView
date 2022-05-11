using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using System.Linq;

namespace Core.Logging
{
    public class LogDAO
    {
        private readonly SqlDataAccess _db;
        public LogDAO()
        {
            _db = new SqlDataAccess();
        }

        public LogDAO(SqlDataAccess db)
        {
            _db = db;
        }
        public async Task<int> StoreLogAsync(Log log)
        {
            var newLog = new
            {
                description = log.Description,
                logLevel = log.Level,
                logCategory = log.Category,
                timeStamp = log.timeStamp
            };

            return await _db.SaveData("dbo.Logs_StoreLogs", newLog);
        }

        public async Task<IEnumerable<Log>> GetLogAsync(int id)
        {
            return await _db.LoadData<Log, dynamic>("dbo.Logs_GetLog", new { Id = id });
        }

        public async Task<IEnumerable<Log>> GetOldLogsAsync()
        {
            return await _db.LoadData<Log, dynamic>("dbo.Logs_GetOldLog", "");
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync()
        {
            return await _db.LoadData<Log, dynamic>("dbo.Logs_GetAllLogs", new { timeStamp = DateTime.Now });
        }

        public async Task<int> DeleteOldLogsAsync()
        {
            return await _db.SaveData("dbo.Logs_RemoveOldLogs", new { });
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(DateTime time)
        {
            return await _db.LoadData<Log, dynamic>("dbo.Logs_GetLogTimes", new { timeStamp = time });
        }
    }
}

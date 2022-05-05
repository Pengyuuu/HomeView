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

            return await _db.SaveData("dbo.StoreLogs", newLog);
        }

        public async Task<Log?> GetLog(int id)
        {

            var results = await _db.LoadData<Log, dynamic>("dbo.GetLog", new { Id = id });
            return results.FirstOrDefault();
        }

        public Task<IEnumerable<Log>> GetOldLogs()
        {
            Task<IEnumerable<Log>> results;

            try
            {
                results = _db.LoadData<Log, dynamic>("dbo.GetOldLog", "");
            }
            catch (Exception e)
            {
                results = null;
            }

            return results;
        }

        public Task DeleteOldLogs()
        {
            return _db.SaveData("dbo.RemoveOldLogs", new { });
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(DateTime time)
        {
            return await _db.LoadData<Log, dynamic>("dbo.GetLogsTime", new { timeStamp = time });
        }
    }
}

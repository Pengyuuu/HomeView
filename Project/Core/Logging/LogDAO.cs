using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Data;
using System.Linq;

namespace Logging
{
    public class LogDAO
    {
        private readonly SqlDataAccess _db;
        public LogDAO()
        {
        }

        public LogDAO(SqlDataAccess db)
        {
            _db = db;
        }
        public Task StoreLog(Log log)
        {
            return _db.SaveData("dbo.StoreLogs", new { description = log.Description, logLevel = log.Level, logCategory = log.Category, timeStamp = log.timeStamp });
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
                results = _db.LoadData<Log, dynamic>("dbo.GetOldLogs", "");
            }
            catch (Exception e)
            {
                results = null;
            }

            return results;
        }

        public Task DeleteOldLogs()
        {
            return _db.SaveData("dbo.RemoveOldLogs", new { timeStamp = DateTime.UtcNow });
        }

        public Task<IEnumerable<Log>> GetLogs(DateTime time)
        {
            Task<IEnumerable<Log>> results;

            try
            {
                results = _db.LoadData<Log, dynamic>("dbo.GetLogsTime", new { timeStamp = time });
            }
            catch (Exception e)
            {
                results = null;
            }

            return results;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Data;

namespace Logging
{
    public class LogDAO
    {
        private readonly SqlDataAccess _db;
        public LogDAO(LoggingService logService)
        {
        }

        public LogDAO(SqlDataAccess db)
        {
            _db = db;
        }
        public Task StoreLog(Log log)
        {
            return _db.SaveData("dbo.StoreLogs", new { log.Description, log.Level, log.Category, log.timeStamp });
            /*
            SqlConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString());
            SqlCommand command = new SqlCommand("StoreLogs", conn);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = log.Description;
                command.Parameters.Add("@logLevel", SqlDbType.NVarChar).Value = log.Level;
                command.Parameters.Add("@logCategory", SqlDbType.NVarChar).Value = log.Category;
                command.Parameters.Add("@timeStamp", SqlDbType.DateTime).Value = log.timeStamp;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                conn.Close();
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
            */
        }

        public Task<IEnumerable<Log>> GetLog(int id)
        {
            Task<IEnumerable<Log>> results;

            try
            {
                results = _db.LoadData<Log, dynamic>("dbo.GetLog", new { Id = id });
            }
            catch (Exception e)
            {
                results = null;
            }

            return results;
            /*
            Log log = null;
            SqlConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString());
            SqlCommand command = new SqlCommand("GetLog", conn);
            LogLevel logLev;
            LogCategory logCat;
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataReader read = command.ExecuteReader();

                if(read.HasRows)
                {
                    while(read.Read())
                    {
                        log = new();
                        log.Id = read.GetInt32(0);
                        log.Description = read.GetString(1);
                        if (Enum.TryParse(read.GetString(2), out logLev))
                        {
                            log.Level = logLev;
                        }
                        if (Enum.TryParse(read.GetString(3), out logCat))
                        {
                            log.Category = logCat;
                        }
                        log.timeStamp = read.GetDateTime(4);
                    }
                }
            }
            catch (SqlException e)
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();
            }
            return log;
            */
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
            return _db.LoadData<Log, dynamic>("dbo.RemoveOldLogs", "");
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

﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Logging.Logging
{
    public class LogDAO
    {
        public LogDAO(LoggingService logService)
        {
            
        }
        public bool storeLog(Log log )
        {
            SqlConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString());
            SqlCommand command = new SqlCommand("StoreLogs", conn);
            try
            {
                conn.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userOperation", SqlDbType.NVarChar).Value = log.UserOperation;
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
        }

        public Log getLog(int id)
        {
            Log log = new Log();
            SqlConnection conn = new SqlConnection(Data.ConnectionString.getConnectionString());
            SqlCommand command = new SqlCommand("GetLog", conn);
            LogUserOperation userOp;
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
                        log.Id = read.GetInt32(0);
                        if(Enum.TryParse(read.GetString(1), out userOp))
                        {
                            log.UserOperation = userOp;
                        }
                        log.Description = read.GetString(2);
                        if (Enum.TryParse(read.GetString(3), out logLev))
                        {
                            log.Level = logLev;
                        }
                        if (Enum.TryParse(read.GetString(4), out logCat))
                        {
                            log.Category = logCat;
                        }
                        log.timeStamp = read.GetDateTime(5);
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
        }
    }
}

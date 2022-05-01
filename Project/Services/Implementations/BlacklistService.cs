using System;
using System.Collections.Generic;
using System.Linq;
using Features.Blacklist;
using Services.Contracts;
using Core.Logging;
using Data;


namespace Services.Implementations
{
    public class BlacklistService : IBlacklistService
    {
        private BlacklistDAO _bDAO;
        private ILoggingService _loggingService;

        public BlacklistService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _bDAO = new BlacklistDAO(db);
            _loggingService = new LoggingService();
        }

        // return true if rowsEffected = 1, else return false
        public bool AddToBlacklist(Blacklist blacklistItem)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncAddToBlacklist(blacklistItem).Result;

                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in AddToBlackList.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0 || rowsEffected > 1)
                {
                    Log blacklistLogFalse = new(rowsEffected + " rows effected in AddToBlacklist.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                return false;
            }
            catch
            {
                Log blacklistLogFalse = new("Cannot add blacklist item to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogFalse);

                return false;
            }
        }

        // return true if successfully fetched from db and contains anything, else return null
        public IEnumerable<string> GetBlacklist(Blacklist selectedUser)
        {
            IEnumerable<string> fetchBlacklist = Enumerable.Empty<string>();
            try
            {
                fetchBlacklist = _bDAO.AsyncGetBlacklist(selectedUser).Result;

                Log blacklistLogTrue = new("Successfully fetched backlist from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogTrue);

                if (fetchBlacklist.Any())
                {
                    return fetchBlacklist;
                }
                return null;
            }
            catch
            {
                Log blacklistLogFalse = new("Cannot fetch blacklist from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogFalse);

                return null;
            }
        }
        // return user's blacklist toggle option (true/false or on/off)
        public bool GetBlacklistToggle(Blacklist selectedUser)
        {
            return _bDAO.AsyncGetBlacklistToggle(selectedUser).Result.FirstOrDefault();


            Log blacklistLogTrue = new("Successfully fetched blacklist toggle from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
            _loggingService.LogData(blacklistLogTrue);

        }
        // return true if rowsEffected = 1, else return false
        public bool RemoveFromBlacklist(Blacklist blacklistItem)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncRemoveFromBlacklist(blacklistItem).Result;
                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in RemoveFromBlacklist.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0 || rowsEffected > 1)
                {
                    Log blacklistLogFalse = new(rowsEffected + " rows effected in RemoveFromBlacklist.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                return false;
            }
            catch
            {
                Log blacklistLogFalse = new("Cannot remove blacklist item from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogFalse);

                return false;
            }
        }

        // return true if rowsEffected = 1, else return false
        public bool UpdateToggleBlacklist(Blacklist selectedUser)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncUpdateToggleBlacklist(selectedUser).Result;

                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in UpdateToggleBlacklist.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0 || rowsEffected > 1)
                {
                    Log blacklistLogFalse = new(rowsEffected + " rows effected in UpdateToggleBlacklist.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                return false;
            }
            catch
            {
                Log blacklistLogFalse = new("Cannot update toggleblackist in database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogFalse);

                return false;
            }
        }
    }
}

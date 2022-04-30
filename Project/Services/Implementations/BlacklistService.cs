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

        public bool AddToBlacklist(Blacklist blacklistItem)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncAddToBlacklist(blacklistItem).Result;
                Console.WriteLine("AddToBlacklist " + rowsEffected);

                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in AddToBlackList.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0)
                {
                    Log blacklistLogFalse = new("Zero rows effected in AddToBlackList.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                if (rowsEffected < 1)
                {
                    Log blacklistLogFalse = new(rowsEffected + " rows effected in AddToBlackList.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
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

        public IEnumerable<string> GetBlacklist(Blacklist selectedUser)
        {
            IEnumerable<string> fetchBlacklist = Enumerable.Empty<string>();
            try
            {
                fetchBlacklist = _bDAO.AsyncGetBlacklist(selectedUser).Result;
                Console.WriteLine("GetBlacklist " + fetchBlacklist);

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

        public bool? GetBlacklistToggle(Blacklist selectedUser)
        {
            bool? isToggle = null;
            try
            {
                int fetchToggle = _bDAO.AsyncGetBlacklistToggle(selectedUser).Result;
                Console.WriteLine("GetBlacklistToggle " + fetchToggle);

                Log blacklistLogTrue = new("Successfully fetched blacklist toggle from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogTrue);

                if (fetchToggle == 1)
                {
                    isToggle = true;
                    return isToggle;
                }
                if (fetchToggle == 0)
                {
                    isToggle = false;
                    return isToggle;
                }
                return isToggle;
            }
            catch
            {
                Log blacklistLogFalse = new("Cannot fetch blacklist toggle from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(blacklistLogFalse);

                return isToggle;
            }

            
        }

        public bool RemoveFromBlacklist(Blacklist blacklistItem)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncRemoveFromBlacklist(blacklistItem).Result;
                Console.WriteLine("RemoveFromBlacklist " + rowsEffected);
                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in RemoveFromBlacklist.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0)
                {
                    Log blacklistLogFalse = new("Zero rows effected in RemoveFromBlacklist.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                if (rowsEffected < 1)
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

        public bool UpdateToggleBlacklist(Blacklist selectedUser)
        {
            try
            {
                int rowsEffected = _bDAO.AsyncRemoveFromBlacklist(selectedUser).Result;
                Console.WriteLine("UpdateToggleBlacklist: " + rowsEffected);
                if (rowsEffected == 1)
                {
                    Log blacklistLogTrue = new("One row effected in UpdateToggleBlacklist.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogTrue);
                    return true;
                }
                if (rowsEffected == 0)
                {
                    Log blacklistLogFalse = new("Zero rows effected in UpdateToggleBlacklist.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                    _loggingService.LogData(blacklistLogFalse);
                }
                if (rowsEffected < 1)
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

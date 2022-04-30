using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Logging;
using Data;
using Features.WatchLater;
using Services.Contracts;

namespace Services.Implementations
{
    public class WatchLaterService : IWatchLaterService
    {
        private readonly WatchLaterDAO _watchLaterDAO;
        private readonly ILoggingService _logging;

        public WatchLaterService()
        {
            SqlDataAccess db = new SqlDataAccess();

            _watchLaterDAO = new WatchLaterDAO(db);

            _logging = new LoggingService();
        }

        public bool AddToWatchLater(WatchLaterTitle selectedTitle)
        {
            var result = _watchLaterDAO.AsyncAddToWatchLater(selectedTitle).Result;

            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not added to {selectedTitle.Email}'s WatchLater",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogData(error);

                return false;
            }

            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later adding {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogData(error);

                return false;
            }

            Log success = new Log
            {
                Description = $"Successfully added {selectedTitle.Title} ({selectedTitle.Year}) to {selectedTitle.Email}",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            _logging.LogData(success);

            return true;
        }

        public bool RemoveFromList(WatchLaterTitle selectedTitle)
        {
            var result = _watchLaterDAO.AsyncRemoveFromList(selectedTitle).Result;

            if (result == 0)
            {
                Log error = new Log
                {
                    Description = $"{selectedTitle.Title} ({selectedTitle.Year}) not removed from {selectedTitle.Email}'s Watch Later",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogData(error);

                return false;
            }

            if (result > 1)
            {
                Log error = new Log
                {
                    Description = $"Multiple rows affected in Watch Later removing {selectedTitle.Title} ({selectedTitle.Year}) for {selectedTitle.Email}",
                    Level = LogLevel.Error,
                    Category = LogCategory.DataStore,
                    timeStamp = DateTime.UtcNow
                };

                _logging.LogData(error);

                return false;
            }

            Log success = new Log
            {
                Description = $"Successfully removed {selectedTitle.Title} ({selectedTitle.Year}) from {selectedTitle.Email}'s Watch Later",
                Level = LogLevel.Info,
                Category = LogCategory.DataStore,
                timeStamp = DateTime.UtcNow
            };

            _logging.LogData(success);

            return true;
        }

        public IEnumerable<WatchLaterTitle> GetList(string userEmail)
        {
            return _watchLaterDAO.AsyncGetList(userEmail).Result;
        }

        List<WatchLaterTitle> IWatchLaterService.GetList(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}

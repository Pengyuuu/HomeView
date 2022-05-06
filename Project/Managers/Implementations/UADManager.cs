using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts;
using Services.Implementations;

namespace Managers.Implementations
{
    public class UADManager
    {
        private readonly INewsService _newsService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;
        public UADManager()
        {
            //_newsService = new NewsService();
            _userService = new UserService();
            _loggingService = new LoggingService();

        }

        public List<int> GetRegistrationCount()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20 21:51:20.893]
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }

        public List<int> GetLogInCount()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20];
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }

        public List<int> GetNewsCount()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20];
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }

        /* Gets number of reviews made per day within 3 months
         * Returns an array to be used for trend chart in front end
         */
        public List<int> GetReviewCount()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20];
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }

        /* Gets the top 5 most visited view of all time
         * Returns an array to be used for bar chart in front end
         */
        public List<int> GetTopMostVisitedView()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20];
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }

        /* Gets the top 5 average duration per view of all time
         * Returns an array to be used for bar chart in front end
         */
        public List<int> GetTopViewDuration()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            var recent = today.Month - 3;
            DateTime previous = new DateTime(recent);
            var history = previous.AddDays(92);
            //var sampleDates = [2022 - 04 - 20];
            for (var i = previous; i <= history; i = i.AddDays(1))
            {
                
            }
            return registrationCount;
        }
    }
}

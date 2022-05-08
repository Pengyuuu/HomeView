using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Logging;
using Services.Contracts;
using Services.Implementations;

namespace Managers.Implementations
{
    public class UADManager
    {
        private readonly INewsService _newsService;
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;
        private readonly IRatingAndReviewService _ratingAndReviewService;
        public UADManager()
        {
            _newsService = new NewsService(new Features.News.NewsDAO(new Data.SqlDataAccess()));
            _userService = new UserService();
            _loggingService = new LoggingService();
            _ratingAndReviewService = new RatingAndReviewService();

        }

        /* Gets a list of the number of registrations per day within the span of 3 months
         * Returns a list of int
         */
        public List<int> GetRegistrationCount()
        {
            List<int> registrationCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                registrationCount.Add(_userService.AsyncGetRegistrationCount(i).Result);
            }
            return registrationCount;
        }

        /* Gets a list of the number of log ins per day within the span of 3 months
         * Returns a list of int
         */
        public List<int> GetLogInCount()
        {
            List<int> loginCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = _loggingService.GetLogAsync(i).Result;
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Successfully created user session.")
                    {
                        dayCount++;
                    }
                }
                loginCount.Add(dayCount);
            }
            return loginCount;
        }

        /* Gets a list of the number of news articles created per day within the span of 3 months
         * Returns a list of int
         */
        public List<int> GetNewsCount()
        {
            List<int> newsCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                newsCount.Add(_newsService.AsyncGetNewsDateCount(i).Result);
            }
            return newsCount;
        }

        /* Gets number of reviews made per day within 3 months
         * Returns an array to be used for trend chart in front end
         */
        public List<int> GetReviewCount()
        {
            List<int> reviewCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = _loggingService.GetLogAsync(i).Result;
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Review successfully created to database.")
                    {
                        dayCount++;
                    }
                }
                reviewCount.Add(dayCount);
            }
            return reviewCount;

            /**
            List<int> reviewCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                reviewCount.Add(_ratingAndReviewService.AsyncGetReviewDateCount(i).Result);
            }
            return reviewCount;**/

        }     

        /* Gets the top 5 most visited view of all time
         * Returns an array to be used for bar chart in front end
         */
        public List<int> GetTopMostVisitedView()
        {
            List<int> loginCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = _loggingService.GetLogAsync(i).Result;
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Successfully created user session.")
                    {
                        dayCount++;
                    }
                }
                loginCount.Add(dayCount);
            }
            return loginCount;
        }

        /* Gets the top 5 average duration per view of all time
         * Returns an array to be used for bar chart in front end
         */
        public List<int> GetTopViewDuration()
        {
            List<int> loginCount = new List<int>();
            var today = DateTime.Now;
            // gets the month of 3 months ago
            var recent = today.Month - 3;
            // gets the first day of the month from 3 months ago
            DateTime previous = new DateTime(today.Year, recent, today.Day);
            // adds 92 days (3 months) to get the end date
            var history = previous.AddDays(92);

            for (var i = previous; i <= today; i = i.AddDays(1))
            {
                var dayLogs = _loggingService.GetLogAsync(i).Result;
                int dayCount = 0;
                foreach (Log j in dayLogs)
                {
                    if (j.Description == "Successfully created user session.")
                    {
                        dayCount++;
                    }
                }
                loginCount.Add(dayCount);
            }
            return loginCount;
        }
    }
}

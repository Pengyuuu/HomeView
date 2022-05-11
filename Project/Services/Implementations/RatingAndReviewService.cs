using System;
using System.Collections.Generic;
using System.Linq;
using Features.Ratings_and_Reviews;
using Services.Contracts;
using Core.Logging;
using Data;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class RatingAndReviewService : IRatingAndReviewService
    {
        private RatingAndReviewDAO _rrDAO;
        private ILoggingService _loggingService;

        public RatingAndReviewService()
        {
            SqlDataAccess db = new SqlDataAccess();
            _rrDAO = new RatingAndReviewDAO(db);
            _loggingService = new LoggingService();
        }

        public async Task<int> AsyncCreateRatingReview(RatingAndReview userRatingAndReview)
        {

            int isCreated = await _rrDAO.AsyncCreateRatingReview(userRatingAndReview);
            if (isCreated == 1)
            {
                Log reviewLogTrue = new("Review successfully created to database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(reviewLogTrue);
            }
            else
            {
                Log reviewLogFalse = new("Cannot create review to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(reviewLogFalse);
            }
            return isCreated;
        }

        public async Task<int> AsyncUpdateRatingReview(RatingAndReview userRatingAndReview)
        {

            int isUpdated = await _rrDAO.AsyncUpdateRateReview(userRatingAndReview);
            if (isUpdated == 1)
            {
                Log reviewLogTrue = new("Review successfully updated to database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);

               await  _loggingService.LogDataAsync(reviewLogTrue);
            }
            else
            {
                Log reviewLogFalse = new("Cannot update review to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);

                await _loggingService.LogDataAsync(reviewLogFalse);
            }
            return isUpdated;

        }

        public async Task<IEnumerable<RatingAndReview?>> AsyncGetRatingReview(RatingAndReview getReview)
        {
            IEnumerable<RatingAndReview> fetchRatingReview = await _rrDAO.AsyncGetRatingReviews(getReview);
            var list = fetchRatingReview.ToList();
            if (list.Count != 0)
            {
                Log reviewLogTrue = new("Review successfully fetched from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogTrue);
                
                if (fetchRatingReview.Any())
                {
                    return fetchRatingReview;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Log reviewLogFalse = new("Cannot fetch review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogFalse);
            }
            return fetchRatingReview;


        }

        public async Task<int> AsyncDeleteRatingReview(RatingAndReview selectedReview)
        {
            int isDeleted = 0;
            isDeleted = await _rrDAO.AsyncDeleteRatingReview(selectedReview);
            if (isDeleted == 1)
            {
            
                Log reviewLogTrue = new("Review successfully deleted from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogTrue);
            }
            if (isDeleted != 1)
            {
                Log reviewLogFalse = new("Unsuccessful delete review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogFalse);
            }
            return isDeleted;

        }

        public async Task<int> AsyncGetReviewDateCount(DateTime date)
        {
            int count = 0;
            count = await _rrDAO.AsyncGetReviewCount(date);
            if (count >= -1)
            {

                Log reviewLogTrue = new("Successful fetched review count from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogTrue);
            }
            else
            {
                Log reviewLogFalse = new("Unsuccessful fetched review count from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                await _loggingService.LogDataAsync(reviewLogFalse);
            }
            return count;

        }

    }
}

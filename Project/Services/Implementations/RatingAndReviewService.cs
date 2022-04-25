using System;
using System.Collections.Generic;
using System.Linq;
using Features.Ratings_and_Reviews;
using Services.Contracts;
using Core.Logging;
using Data;

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

        public bool CreateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncCreateRatingReview(userRatingAndReview).Result;
                Log reviewLogTrue = new("Review successfully created to database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogTrue);
            }
            catch
            {
                Log reviewLogFalse = new("Cannot create review to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return false;
            }
            return isCreated;

        }

        public bool UpdateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isUpdated = false;
            try
            {
                isUpdated = _rrDAO.AsyncUpdateRateReview(userRatingAndReview).Result;
                Log reviewLogTrue = new("Review successfully updated to database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogTrue);
            }
            catch
            {
                Log reviewLogFalse = new("Cannot update review to database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return false;
            }
            return isUpdated;

        }

        public IEnumerable<RatingAndReview> GetRatingReview(RatingAndReview getReview)
        {
            IEnumerable<RatingAndReview> fetchRatingReview = Enumerable.Empty<RatingAndReview>();
            try
            {
                fetchRatingReview = _rrDAO.AsyncGetRatingReviews(getReview).Result;
                Log reviewLogTrue = new("Review successfully fetched from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogTrue);
                if (fetchRatingReview.Any())
                {
                    return fetchRatingReview;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                Log reviewLogFalse = new("Cannot fetch review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return null;
            }
        }

        public bool DeleteRatingReview(RatingAndReview selectedReview)
        {
            bool isDeleted = false;
            try
            {
                RatingAndReview userTitleReview = GetRatingReview(selectedReview).FirstOrDefault();
                if (userTitleReview is not null)
                {
                    try
                    {
                        isDeleted = _rrDAO.AsyncDeleteRatingReview(selectedReview).Result;
                        if (isDeleted)
                        {
                            Log reviewLogTrue = new("Review successfully deleted from database.", LogLevel.Info, LogCategory.DataStore, DateTime.Now);
                            _loggingService.LogData(reviewLogTrue);
                            return true;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                Log reviewLogFalse = new("Unsuccessful delete review from database.", LogLevel.Error, LogCategory.DataStore, DateTime.Now);
                _loggingService.LogData(reviewLogFalse);
                return isDeleted;
            }
            catch
            {
                return false;
            }
        }

    }
}

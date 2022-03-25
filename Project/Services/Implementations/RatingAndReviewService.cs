using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Features.Ratings_and_Reviews;
using Services.Contracts;

namespace Services.Implementations
{
    public class RatingAndReviewService : IRatingAndReviewService
    {
        private RatingAndReviewDAO _rrDAO;
        private ILoggingService _loggingService;

        public RatingAndReviewService()
        {

        }

        public bool CreateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncCreateRatingReview(userRatingAndReview).Result;
            }
            catch
            {
                return false;
            }
            return isCreated;

        }

        public bool UpdateRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncUpdateRateReview(userRatingAndReview).Result;
            }
            catch
            {
                return false;
            }
            return isCreated;

        }

        public RatingAndReview GetRatingReview(string userEmail)
        {

            RatingAndReview fetchRatingReview = new RatingAndReview();

            fetchRatingReview = _rrDAO.AsyncGetRatingReview(userEmail).Result;


            return fetchRatingReview;

        }

        public bool DeleteRatingReview(RatingAndReview userRatingAndReview)
        {

            bool isCreated = false;
            try
            {
                isCreated = _rrDAO.AsyncDeleteRatingReview(userRatingAndReview).Result;
            }
            catch
            {
                return false;
            }
            return isCreated;

        }


    }
}

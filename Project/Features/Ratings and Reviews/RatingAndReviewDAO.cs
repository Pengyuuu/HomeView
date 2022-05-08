using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Features.Ratings_and_Reviews
{
    public class RatingAndReviewDAO
    {

        private readonly SqlDataAccess _db;

        public RatingAndReviewDAO(SqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> AsyncCreateRatingReview(RatingAndReview userRatingReview)
        {
            var ratingReview = new
            {
                dispName = userRatingReview.DispName,
                title = userRatingReview.Title,          
                rating = userRatingReview.Rating,
                review = userRatingReview.Review,
            };

            return await _db.SaveData("dbo.RatingReviews_CreateRatingReview", ratingReview);

        }

        public async Task<int> AsyncUpdateRateReview(RatingAndReview userRatingReview)
        {
            var newRatingReview = new
            {
                dispName = userRatingReview.DispName,
                title = userRatingReview.Title,
                rating = userRatingReview.Rating,
                review = userRatingReview.Review,
            };

            return await _db.SaveData("dbo.RatingReviews_UpdateRatingReview", newRatingReview);

        }

        public async Task<IEnumerable<RatingAndReview>> AsyncGetRatingReviews(RatingAndReview fetchReview)
        {
            // fetch a user's list of reviews
            if ((fetchReview.DispName.Length != 0) && (fetchReview.Title.Length == 0))
            {
                var fetchUserReviews = new
                {
                    dispName = fetchReview.DispName

                };

                return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadUserRatingReview", fetchUserReviews);

            }

            // fetch a title's list of reviews ""
            else if ((fetchReview.Title.Length != 0) && (fetchReview.DispName.Length == 0))
            {
                var fetchTitlesRatingReview = new
                {
                    title = fetchReview.Title

                };

                return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadTitleRatingReview", fetchTitlesRatingReview);

            }

            // fetch a user's review for a specific title
            else if ((fetchReview.Title.Length != 0) && (fetchReview.DispName.Length != 0))
            {
                var fetchUserTitleRatingReview = new
                {
                    dispName = fetchReview.DispName,
                    title = fetchReview.Title

                };
 
                return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadUserTitleRatingReview", fetchUserTitleRatingReview);
 
            }
            else
            {
                return null;
            }
        }

        public async Task<int> AsyncDeleteRatingReview(RatingAndReview selectedReview)
        {
            var deleteReview = new
            {
                dispName = selectedReview.DispName,
                title = selectedReview.Title
            };

            return await _db.SaveData("dbo.RatingReviews_DeleteRatingReview", deleteReview);

        }

        public async Task<int> AsyncGetReviewCount(DateTime date)
        {
            var selectedDate = new
            {
                reviewDate = date
            };

            var result = await _db.LoadData<int, dynamic>("dbo.RatingReviews_GetReviewCountDate", selectedDate);
            if (result.Count() == 1)
            {
                return result.FirstOrDefault();
            }
            return -1;
        }
    }
}

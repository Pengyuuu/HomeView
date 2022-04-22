using System.Collections.Generic;
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

        public async Task<bool> AsyncCreateRatingReview(RatingAndReview userRatingReview)
        {
            var ratingReview = new
            {
                dispName = userRatingReview.DispName,
                title = userRatingReview.Title,          
                rate = userRatingReview.Rating,
                review = userRatingReview.Review            
            };
            try
            {
                await _db.SaveData("dbo.RatingReviews_CreateRatingReview", ratingReview);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AsyncUpdateRateReview(RatingAndReview userRatingReview)
        {
            var newRatingReview = new
            {
                dispName = userRatingReview.DispName,
                title = userRatingReview.Title,
                rate = userRatingReview.Rating,
                review = userRatingReview.Review
            };
            try
            {
                await _db.SaveData("dbo.RatingReviews_UpdateRatingReview", newRatingReview);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<RatingAndReview>> AsyncGetRatingReviews(RatingAndReview fetchReview)
        {
            // fetch a user's list of reviews
            if ((fetchReview.DispName != "") && (fetchReview.Title == ""))
            {
                var fetchUserReviews = new
                {
                    dispName = fetchReview.DispName

                };
                try
                {
                    return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadUserRatingReview", fetchUserReviews);

                }
                catch
                {
                    return null;
                }
            }

            // fetch a title's list of reviews
            else if ((fetchReview.Title != "") && (fetchReview.DispName == ""))
            {
                var fetchTitlesRatingReview = new
                {
                    title = fetchReview.Title

                };
                try
                {
                    return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadTitleRatingReview", fetchTitlesRatingReview);
                }
                catch
                {
                    return null;
                }
            }

            // fetch a user's review for a specific title
            else if ((fetchReview.Title != "") && (fetchReview.DispName != ""))
            {
                var fetchUserTitleRatingReview = new
                {
                    dispName = fetchReview.DispName,
                    title = fetchReview.Title

                };
                try
                {
                    return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadUserTitleRatingReview", fetchUserTitleRatingReview);
                }
                catch
                {
                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        public async Task<bool> AsyncDeleteRatingReview(RatingAndReview selectedReview)
        {
            var deleteReview = new
            {
                dispName = selectedReview.DispName,
                title = selectedReview.Title
            };
            try
            {
                await _db.SaveData("dbo.RatingReviews_DeleteRatingReview", deleteReview);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                review = userRatingReview.Review,
               
            };
            try
            {
                await _db.SaveData("dbo.RatingReviews_CreateRatingReview", userRatingReview);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> AsyncUpdateRateReview(RatingAndReview userRatingReview)
        {
            var newRatingReview = new
            {
                dispName = userRatingReview.DispName,
                title = userRatingReview.Title,
                rate = userRatingReview.Rating,
                review = userRatingReview.Review,

            };
            try
            {
                await _db.SaveData("dbo.RatingReviews_UpdateRatingReview", newRatingReview);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<RatingAndReview>> AsyncGetUsersRatingReviews(string inputDispName)
        {
            var fetchUserReviews = new
            {
                dispName = inputDispName

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

        public async Task<IEnumerable<RatingAndReview>> AsyncGetTitlesRatingsReviews(string inputtedTitle)
        {

            var fetchTitlesRatingReview = new
            {
                title = inputtedTitle

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

        public async Task<RatingAndReview?> AsyncGetUserTitleRatingsReviews(string inputName, string inputTitle)
        {

            var fetchUserTitleRatingReview = new
            {
                dispName = inputName,
                title = inputTitle

            };
            try
            {
                var result =  await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingReviews_ReadTitleRatingReview", fetchUserTitleRatingReview);
                return result.FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AsyncDeleteRatingReview(string inputName, string titleSelected)
        {
            var deleteReview = new
            {
                dispName = inputName,
                title = titleSelected
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

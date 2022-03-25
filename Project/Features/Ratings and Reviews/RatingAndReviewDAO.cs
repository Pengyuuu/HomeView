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
                rate = userRatingReview.Rating,
                review = userRatingReview.Review,
               
            };
            try
            {
                await _db.SaveData("dbo.RatingAndReview_CreateRatingReview", userRatingReview);
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
                newRate = userRatingReview.Rating,
                newReview = userRatingReview.Review,

            };
            try
            {
                await _db.SaveData("dbo.RatingAndReview_UpdateRatingReview", newRatingReview);
            }
            catch
            {
                return false;
            }
            return true;
        }

        // need to fix
        public async Task<RatingAndReview?> AsyncGetRatingReview(string email)
        {
            var fetchRatingReview = new
            {
                userEmail = email

            };
            try
            {
                var results = await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingAndReview_GetRatingReview", fetchRatingReview);
                return results.FirstOrDefault();

            }
            catch
            {
                return null;
            }
        }

        // need to fix
        public async Task<IEnumerable<RatingAndReview>> AsyncGetAllRatingsReviews()
        {
            try
            {
                return await _db.LoadData<RatingAndReview, dynamic>("dbo.RatingAndReview_GetAllRatingReview", new { });
            }
            catch
            {
                return null;
            }
        }

        // need to fix
        public async Task<bool> AsyncDeleteRatingReview(RatingAndReview deleteRatingReview)
        {
            var user = new
            {
                email = email
            };
            try
            {
                await _db.SaveData("dbo.RatingAndReview_CreateRatingReview", user);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

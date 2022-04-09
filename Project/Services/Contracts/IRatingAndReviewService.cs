using Features.Ratings_and_Reviews;
using System.Collections.Generic;


namespace Services.Contracts
{
    public interface IRatingAndReviewService
    {
        bool CreateRatingReview(RatingAndReview userRatingAndReview);
        bool DeleteRatingReview(RatingAndReview selectedReview);
        IEnumerable<RatingAndReview> GetRatingReview(RatingAndReview getReview);
        bool UpdateRatingReview(RatingAndReview userRatingAndReview);
    }
}
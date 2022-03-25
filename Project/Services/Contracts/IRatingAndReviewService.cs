using Features.Ratings_and_Reviews;

namespace Services.Contracts
{
    public interface IRatingAndReviewService
    {
        bool CreateRatingReview(RatingAndReview userRatingAndReview);
        bool DeleteRatingReview(RatingAndReview userRatingAndReview);
        RatingAndReview GetRatingReview(string userEmail);
        bool UpdateRatingReview(RatingAndReview userRatingAndReview);
    }
}
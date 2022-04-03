using Features.Ratings_and_Reviews;

namespace Services.Contracts
{
    public interface IRatingAndReviewService
    {
        bool CreateRatingReview(RatingAndReview userRatingAndReview);
        bool DeleteRatingReview(string dispName, string titleSelected);
        RatingAndReview GetRatingReview(string dispName, string titleSelected);
        bool UpdateRatingReview(RatingAndReview userRatingAndReview);
    }
}
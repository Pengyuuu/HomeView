using System.Collections.Generic;

namespace Features.Ratings_and_Reviews
{
    public class TitleInfo
    {
        private double _avgRating;
        private List<RatingAndReview> _ratingAndReviews;

        public TitleInfo(double avg, List<RatingAndReview> reviewsList )
        {
            _avgRating = avg;
            _ratingAndReviews = reviewsList;
        }
    }
}

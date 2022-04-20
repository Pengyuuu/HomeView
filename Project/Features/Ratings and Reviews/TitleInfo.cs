using System;
using System.Collections.Generic;

namespace Features.Ratings_and_Reviews
{
    public class TitleInfo
    {
        private double _avgRating;
        private List<RatingAndReview> _ratingAndReviews;

        public double Rating { get; set; }
        public List<RatingAndReview> RatingAndReviews { get; set; }
        public TitleInfo()
        {
            Rating = 0;
            RatingAndReviews = new List<RatingAndReview>();
        }

        public TitleInfo(double avg, List<RatingAndReview> reviewsList )
        {
            _avgRating = avg;
            _ratingAndReviews = reviewsList;
        }

        override
        public String ToString()
        {
            if (this == null)
            {
                return "Title Info not found.";
            }
            return this._avgRating + ", " + this._ratingAndReviews;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Ratings_and_Reviews
{
    public class RatingAndReview
    {
              
        private int _rating;
        private string _review;

        // User's rating for a title
        public int Rating { get; set; }

        // User's review for a title
        public string Review { get; set; }

       
        public RatingAndReview()
        {
            this.Rating = 0;
            this.Review = "";
        }
        public RatingAndReview(int userRating)
        {
            this.Rating = userRating;
            this.Review = "";
        }

        public RatingAndReview(string userReview)
        {
            this.Rating = 0;
            this.Review = userReview;
        }
    }
}

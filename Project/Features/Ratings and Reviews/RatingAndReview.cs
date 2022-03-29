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
        private string _title;

        // User's rating for a title
        public int Rating { get; set; }

        // User's review for a title
        public string Review { get; set; }
        // The given title
        public string Title { get; set; }

       
        public RatingAndReview()
        {
            this.Rating = 0;
            this.Review = "";
            this.Title = "";
        }
        public RatingAndReview(string selectedTitle, int userRating)
        {
            this.Rating = userRating;
            this.Review = "";
            this.Title = selectedTitle;
        }

        public RatingAndReview(string selectedTitle, string userReview)
        {
            this.Rating = 0;
            this.Review = userReview;
            this.Title = selectedTitle;
        }

        public RatingAndReview(string selectedTitle, int userRating, string userReview)
        {
            this.Rating = userRating;
            this.Review = userReview;
            this.Title = selectedTitle;
        }

    }
}

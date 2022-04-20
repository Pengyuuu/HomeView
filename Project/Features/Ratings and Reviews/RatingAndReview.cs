
namespace Features.Ratings_and_Reviews
{
    public class RatingAndReview
    {
        // User's rating for a title
        public double Rating { get; set; }

        // User's review for a title
        public string Review { get; set; }
        // The given title
        public string Title { get; set; }
        public string DispName { get; set; }

       
        public RatingAndReview()
        {
            this.Rating = 0.0;
            this.Review = "";
            this.Title = "";
            this.DispName = "";
        }
        public RatingAndReview(string dispName, string selectedTitle, float userRating)
        {
            this.Rating = userRating;
            this.Review = "";
            this.Title = selectedTitle;
            this.DispName = dispName;
        }

        public RatingAndReview(string dispName, string selectedTitle, string userReview)
        {
            this.Rating = 0.0;
            this.Review = userReview;
            this.Title = selectedTitle;
            this.DispName = dispName;
        }

        public RatingAndReview(string dispName, string selectedTitle, float userRating, string userReview)
        {
            this.Rating = userRating;
            this.Review = userReview;
            this.Title = selectedTitle;
            this.DispName = dispName;
        }
    }
}

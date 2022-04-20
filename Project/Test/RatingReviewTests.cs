using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.Ratings_and_Reviews;
using Managers.Implementations;

namespace RatingReviewTests
{
    public class RatingReviewTests

    {

        RatingAndReviewManager reviewManager = new RatingAndReviewManager();


        [Fact]
        public void ReviewManager_CreateReviewShouldCreateNewReview()
        {
            bool expected = true;
            // name, title, rating, review
            RatingAndReview newReview = new RatingAndReview("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            bool actual = reviewManager.SubmitReviewRating("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_CreateReviewShouldNotCreateForNonExistingUser()
        {
            bool expected = false;

            bool actual = reviewManager.SubmitReviewRating("abcdegfhg", "Testing", 3, "I love the Power Rangers! You should go watch the original! :)");

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ReviewManager_GetAllUserReviews()   
        {

            IEnumerable<RatingAndReview> actual = reviewManager.GetUserReviewRating("HankHill@yahoo.com");
            Assert.True(actual.Any());
        }

        // review must be in db for this
        [Fact]
        public void ReviewManager_GetUserSpecificReviews()   
        {
            RatingAndReview newReview = new RatingAndReview("HankHill@yahoo.com", "Power Rangers");
            string actual = "";
            try
            {
                var result = reviewManager.GetSpecificReviewRating(newReview.DispName, newReview.Title);
                actual = result.ToString();
            }
            catch
            {
                actual = "null";
            }
            string expected = newReview.ToString();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_GetAllTitleReviews()   
        {
            bool hasReviews = false;
            bool expected = true;
            IEnumerable<RatingAndReview> actual = Enumerable.Empty<RatingAndReview>();
            try
            {
                actual = reviewManager.GetTitleReviewRating("Power Rangers");
                if (actual.Any())
                {
                    hasReviews = true;
                }
            }
            catch 
            {
                hasReviews = false;
            }
            Assert.Equal(expected, hasReviews);

        }

        [Fact]
        public void ReviewManager_UpdateUserReviewForTitle()
        {
            RatingAndReview exampleReview = new RatingAndReview("HankHill@yahoo.com", "Power Rangers", 2, "I don't like any series after In Space. It just went downhill.");
            bool isUpdated = reviewManager.UpdateReviewRating("HankHill@yahoo.com", "Power Rangers", 2, "I don't like any series after In Space. It just went downhill.");
            var fetchedUpdate = reviewManager.GetSpecificReviewRating("HankHill@yahoo.com", "Power Rangers");
            string actual = fetchedUpdate.ToString();
            string expected = exampleReview.ToString();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_DeleteReviewSuccesssful()
        {
            bool expected = true;
            bool actual = reviewManager.DeleteReviewRating("HankHill@yahoo.com", "Power Rangers");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReviewManager_DeleteReviewUnSucessful()
        {
            // unsuccessful if user did not create a review for given title
            bool expected = false;
            bool actual = reviewManager.DeleteReviewRating("mWallace@pulp.com", "Power Rangers");
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReviewManager_GetAverageRating()
        {
            // unsuccessful if user did not create a review for given title
            double expected = 5;
            double actual = reviewManager.GetAverageRating("Power Rangers");
            Assert.Equal(expected, actual);
        }
    }
}

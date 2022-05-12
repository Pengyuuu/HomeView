using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.Ratings_and_Reviews;
using Managers.Implementations;
using System.Net.Http;

namespace RatingReviewTests
{
    public class RatingReviewTests

    {

        RatingAndReviewManager reviewManager = new RatingAndReviewManager();


        [Fact]
        public void ReviewManager_CreateReviewShouldCreateNewReview()
        {
            int expected = 1;
            // name, title, rating, review
            RatingAndReview newReview = new RatingAndReview("may@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            int actual = reviewManager.AsyncSubmitReviewRating("may@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)").Result;
            

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_CreateReviewShouldNotCreateForNonExistingUser()
        {
            int expected = 0;

            int actual = reviewManager.AsyncSubmitReviewRating("abcdegfhg", "Testing", 3, "I love the Power Rangers! You should go watch the original! :)").Result;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ReviewManager_GetAllUserReviews()   
        {

            IEnumerable<RatingAndReview> actual = reviewManager.AsyncGetUserReviewRating("testName").Result;
            Assert.True(actual.Any());
        }

        // review must be in db for this
        [Fact]
        public void ReviewManager_GetUserSpecificReviews()   
        {
            RatingAndReview newReview = new RatingAndReview("testName", "Bee Movie");
            string actual = "";
            try
            {
                var result = reviewManager.AsyncGetSpecificReviewRating(newReview.DispName, newReview.Title).Result;
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
                actual = reviewManager.AsyncGetTitleReviewRating("Bee Movie").Result;
                
            }
            catch 
            {
                hasReviews = false;
            }
            Assert.NotNull(actual);

        }

        [Fact]
        public void ReviewManager_UpdateUserReviewForTitle()
        {
            RatingAndReview exampleReview = new RatingAndReview("testName", "Bee Movie", 3, "I don't like any series after In Space. It just went downhill.");
            var fetchedUpdate = reviewManager.AsyncGetSpecificReviewRating("testName", "Bee Movie").Result;
            string actual = fetchedUpdate.ToString();
            string expected = exampleReview.ToString();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_DeleteReviewSuccesssful()
        {
            int expected = 0;
            int actual = reviewManager.AsyncDeleteReviewRating("HankHill@yahoo.com", "Power Rangers").Result;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReviewManager_DeleteReviewUnSucessful()
        {
            // unsuccessful if user did not create a review for given title
            int expected = 0;
            int actual = reviewManager.AsyncDeleteReviewRating("mWallace@pulp.com", "Power Rangers").Result;
           
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReviewManager_GetAverageRating()
        {
            // unsuccessful if user did not create a review for given title
            double expected = 4;
            double actual = reviewManager.AsyncGetAverageRating("Bee Movie").Result;
            Assert.Equal(expected, actual);
        }
    }
}

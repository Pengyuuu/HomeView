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
            RatingAndReview newReview = new RatingAndReview("a", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            bool actual = reviewManager.SubmitReviewRating("a", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            

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

            IEnumerable<RatingAndReview> actual = reviewManager.GetUserReviewRating("a");
            Assert.True(actual.Any());
        }

        // review must be in db for this
        [Fact]
        public void ReviewManager_GetUserSpecificReviews()   
        {
            RatingAndReview newReview = new RatingAndReview("a", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
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
            IEnumerable<RatingAndReview> actual = Enumerable.Empty<RatingAndReview>();
            try
            {
                actual = reviewManager.GetTitleReviewRating("Power Rangers");
            }
            catch 
            {
                // I actually don't know what to put here
            }
            var i = 1 + 1;
            Assert.True(actual.Any());

        }

        [Fact]
        public void ReviewManager_UpdateUserReviewForTitle()
        {
            RatingAndReview exampleReview = new RatingAndReview("a", "Power Rangers", 2, "I don't like any series after In Space. It just went downhill.");
            bool isUpdated = reviewManager.UpdateReviewRating("a", "Power Rangers", 2, "I don't like any series after In Space. It just went downhill.");
            var fetchedUpdate = reviewManager.GetSpecificReviewRating("a", "Power Rangers");
            string actual = fetchedUpdate.ToString();
            string expected = exampleReview.ToString();
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void ReviewManager_DeleteReviewSuccesssful()
        {
            bool expected = true;
            bool actual = reviewManager.DeleteReviewRating("a", "Power Rangers");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReviewManager_DeleteReviewUnSucessful()
        {
            // unsuccessful if does not exist/not in db
            bool expected = false;
            bool actual = reviewManager.DeleteReviewRating("b", "Power Rangers");
           
            Assert.Equal(expected, actual);


        }
    }
}

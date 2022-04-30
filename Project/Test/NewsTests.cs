using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.News;
using Managers.Implementations;


namespace Test
{
    public class NewsTests
    {
        RatingAndReviewManager reviewManager = new RatingAndReviewManager();

        [Fact]
        public void NewsManager_CreateArticleSuccess()
        {
            bool expected = true;
            // name, title, rating, review
            RatingAndReview newReview = new RatingAndReview("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            bool actual = reviewManager.SubmitReviewRating("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");


            Assert.Equal(expected, actual);

        }

        [Fact]
        public void NewsManager_CreateArticleFailure()
        {
            bool expected = true;
            // name, title, rating, review
            RatingAndReview newReview = new RatingAndReview("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");
            bool actual = reviewManager.SubmitReviewRating("HankHill@yahoo.com", "Power Rangers", 5, "I love the Power Rangers! You should go watch the original! :)");


            Assert.Equal(expected, actual);

        }
        [Fact]
        public void NewsManager_ReadArticleSuccess()
        {
            bool expected = false;

            bool actual = reviewManager.SubmitReviewRating("abcdegfhg", "Testing", 3, "I love the Power Rangers! You should go watch the original! :)");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NewsManager_ReadArticleFailure()
        {
            bool expected = false;

            bool actual = reviewManager.SubmitReviewRating("abcdegfhg", "Testing", 3, "I love the Power Rangers! You should go watch the original! :)");

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void NewsManager_ReadAllNewsShouldReturnAllArticles()
        {
            IEnumerable<RatingAndReview> actual = reviewManager.GetUserReviewRating("HankHill@yahoo.com");
            Assert.True(actual.Any());
        }

        [Fact]
        public void NewsManager_UpdateArticleShouldChangeArticle()
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
        public void NewsManager_DeleteArticleSuccess()
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
        public void NewsManager_DeleteArticleFailure()
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
    }
}
}

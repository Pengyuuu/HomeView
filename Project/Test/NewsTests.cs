using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.News;
using Managers.Implementations;


namespace NewsTest
{
    // Arrange, Act, Assert
    public class NewsTests
    {
        NewsManager newsManager = new NewsManager(new NewsService(new NewsDAO(new Data.SqlDataAccess())));

        [Fact]
        public void NewsManager_CreateArticleSuccess()
        {
            //Arrange
            Article newArt = new Article("Test Title", "content", "imgPath") ;

            //Act
            var actual = (Article)newsManager.AsyncCreateArticle(newArt);

            //Assert
            Assert.NotNull(actual);   

        }

        [Fact]
        public void NewsManager_ReadArticleSuccess()
        {
            //Arrange

            //Act
            var actual = newsManager.AsyncGetArticleById(1);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void NewsManager_ReadArticleFailure()
        {
            //Arrange

            //Act
            var actual = newsManager.AsyncGetArticleById(-5);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public void NewsManager_ReadAllNewsShouldReturnAllArticles()
        {
            //Arrange

            //Act
            IEnumerable<Article> actual = (IEnumerable<Article>)newsManager.AsyncGetNews();

            //Assert
            Assert.True(actual.Count() > 1);
        }

        //Testing with first article 
        [Fact]
        public void NewsManager_UpdateArticleShouldChangeArticle()
        {
            //Arrange
            Article newArt = new Article("Test Title", "content", "imgPath");

            //Act
            var actual = newsManager.AsyncCreateArticle(newArt);

            //Assert
            Assert.NotNull(actual);

        }

        [Fact]
        public void NewsManager_DeleteArticleSuccess()
        {

        }

        [Fact]
        public void NewsManager_DeleteArticleFailure()
        {

        }
    }
}


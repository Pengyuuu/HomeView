using System.Collections.Generic;
using System.Linq;
using Xunit;
using Features.News;
using Managers.Implementations;
using System.IO;

namespace NewsTest
{
    // Arrange, Act, Assert
    public class NewsTests
    {
        NewsManager newsManager = new NewsManager();

        [Fact]
        public async void NewsManager_CreateArticleSuccess()
        {
            //Arrange
            Article newArt = new Article("Test Title", "content", "imgPath") ;

            //Act
            var actual = await newsManager.AsyncCreateArticle(newArt);

            //Assert
            Assert.NotNull(actual);   

        }
        /*
        [Fact]
        public async void NewsManager_CreateArticleFailure()
        {
            //Arrange
            //string content = File.ReadAllText("C:\\Users\\danny\\Source\\Repos\\HomeView\\Project\\Test\\50k.txt");
            Article newArt = new Article("Test Title", "", "imgPath");

            //Act
            var actual = await newsManager.AsyncCreateArticle(newArt);

            //Assert
            Assert.NotNull(actual);
        }*/

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
        public async void NewsManager_ReadArticleFailure()
        {
            //Arrange

            //Act
            var actual = await newsManager.AsyncGetArticleById(2010);

            //Assert
            Assert.Null(actual);
        }

        [Fact]
        public async void NewsManager_ReadAllNewsShouldReturnAllArticles()
        {
            //Arrange

            //Act
            IEnumerable<Article> actual = await newsManager.AsyncGetNews();

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


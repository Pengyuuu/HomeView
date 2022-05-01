using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Features.News
{
    /* Standard CRUD operations for News Table */
    public class NewsDAO
    {
        /* A SqlDataAccessObject is used throughout the app 
         * to standardize use of storedprocs*/
        private readonly SqlDataAccess _db;

        public NewsDAO(SqlDataAccess db)
        {
            _db = db;
        }

        /* returns an int, representing the rows affected (success = 1) */
        public async Task<int> AsyncCreateArticle(Article article)
        {
            //Extracts the params from article DTO
            var sp_params = new
            {
                articleTitle = article.ArticleTitle,
                articleContent = article.ArticleContent,
                imgPath = article.ImgPath,
            };
            return await _db.SaveData("dbo.NewsCreate", sp_params);
        }
        
        /* id is optional argument, 
         * leaving it blank results in returning all articles */

        /*
         * make parameter (int?) <- null check, can do away with if statement
         */

        /*
         * dynamic vars can produce err at runtime bcz compilers ignore, don't use, inefficient as well
         * better off passing params 
         */
        public async Task<IEnumerable<Article>> AsyncReadArticles(int articleId=-1)
        {
            if (articleId == -1)
            {
                return await _db.LoadData<Article, dynamic>("dbo.NewsRead", null);
            }
            var sp_params = new
            {
                articleID = articleId,
            };

            return await _db.LoadData<Article, dynamic>("dbo.NewsRead", sp_params);
        }

        /* returns an int, representing the rows affected (success = 1) */
        public async Task<int> AsyncUpdateArticle(Article article)
        {
            //Extracts the params from article DTO
            var sp_params = new
            {
                articleID = article.ArticleId,
                articleTitle = article.ArticleTitle,
                articleContent = article.ArticleContent,
                imgPath = article.ImgPath,
            };
            return await _db.SaveData("dbo.NewsUpdate", sp_params);
        }

        /* returns an int, representing the rows affected (success = 1) */
        public async Task<int> AsyncDeleteArticle(int articleId)
        {
            var sp_params = new
            {
                articleID = articleId,
            };
            return await _db.SaveData("dbo.NewsDelete", sp_params);
        }
    }

}

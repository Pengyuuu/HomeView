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
            return await _db.SaveData("dbo.NewsCreate", article);
        }
        
        /* id is optional argument, 
         * leaving it blank results in returning all articles */
        public async Task<IEnumerable<Article>> AsyncReadArticles(int articleId=-1)
        {
            if (articleId == -1)
            {
                return await _db.LoadData<Article, dynamic>("dbo.NewsRead", null);
            }
            
            return await _db.LoadData<Article, dynamic>("dbo.NewsRead", articleId);
        }

        /* returns an int, representing the rows affected (success = 1) */
        public async Task<int> AsyncUpdateArticle(Article article)
        {
            return await _db.SaveData("dbo.NewsUpdate", article);
        }

        /* returns an int, representing the rows affected (success = 1) */
        public async Task<int> AsyncDeleteArticle(int articleId)
        {
            return await _db.SaveData("dbo.NewsDelete", articleId);
        }
    }

}

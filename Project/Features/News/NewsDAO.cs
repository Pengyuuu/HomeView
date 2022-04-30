using System.Collections.Generic;
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
        public async Task<int> AsyncCreateArticle(Article article)
        {
            return await _db.SaveData("dbo.NewsCreate", article);
        }
        
        public async Task<IEnumerable<string>> AsyncReadArticle(Article article)
        {
            return await _db.LoadData<string, dynamic>("dbo.NewsRead", article);
        }

        public async Task<int> AsyncUpdateArticle(Article article)
        {
            return await _db.SaveData("dbo.NewsUpdate", article);
        }

        public async Task<int> AsyncDeleteArticle(Article article)
        {
            return await _db.SaveData("dbo.NewsDelete", article);
        }
    }

}

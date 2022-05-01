using Features.News;
using Services.Contracts;
using Services.Implementations;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class NewsManager : INewsManager
    {
        private readonly INewsService _newsService;
        private readonly int MAX_ARTICLE_LENGTH = 50000;

        /*
         * constructor DI for layers
         */
        public NewsManager()
        {
            _newsService = new NewsService(new NewsDAO(new Data.SqlDataAccess()));
        }

        public async Task<Article> AsyncCreateArticle(Article article)
        {
            if (article != null)
            {
                if (article.ArticleContent.Length < MAX_ARTICLE_LENGTH)
                {
                    return await _newsService.AsyncCreateArticle(article);
                }
            }
            /* Would it be best to truncate the article, 
            * or refuse completely? */
            return null;
        }

        /*
         * Implement business rule to restrict old articles (past one month)
         */
        public async Task<Article> AsyncGetArticleById(int id)
        {
            if (id > 0)
            {
                return await _newsService.AsyncGetArticleById(id);
            }
            return null;
        }

        /*
         * BR -> only return articles within a month
         */
        public async Task<IEnumerable<Article>> AsyncGetNews()
        {
            return await _newsService.AsyncGetNews();
        }

        /*
         * BR -> only return articles within a month
         */
        public async Task<Article> AsyncUpdateArticleById(Article article)
        {
            if (article != null)
            {
                return await _newsService.AsyncUpdateArticleById(article);
            }
            return null;
        }

        /*
         * security BR only admins
         */
        public async Task<int> AsyncDeleteArticleById(int id)
        {
            if (id > 0)
            {
                return await _newsService.AsyncDeleteArticleById(id);
            }
            return 0;
        }
    }
}




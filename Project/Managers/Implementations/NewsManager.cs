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

        public async Task<Article> AsyncGetArticleById(int id)
        {
            return await _newsService.AsyncGetArticleById(id);
        }

        public async Task<IEnumerable<Article>> AsyncGetNews()
        {
            return  await _newsService.AsyncGetNews();
        }

        public async Task<Article> AsyncUpdateArticleById(Article article)
        {
            return await _newsService.AsyncUpdateArticleById(article);
        }

        public async Task<int> AsyncDeleteArticleById(int id)
        {
            return await _newsService.AsyncDeleteArticleById(id);
        }
    }
}




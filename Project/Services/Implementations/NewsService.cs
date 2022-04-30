using Features.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class NewsService : INewsService
    {

        private readonly NewsDAO _newsDAO;
        public NewsService(NewsDAO dao)
        {
            _newsDAO = dao;
        }

        public async Task<Article> AsyncCreateArticle(Article article)
        {
            await _newsDAO.AsyncCreateArticle(article);
            return article;
        }

        public async Task<Article> AsyncGetArticleById(int id)
        {
            return _newsService.GetArticleById(id);
        }

        public async Task<IEnumerable<Article>> AsyncGetNews()
        {
            return _newsService.GetNews();
        }

        public async Task<Article> AsyncUpdateArticleById(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> AsyncDeleteArticleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}




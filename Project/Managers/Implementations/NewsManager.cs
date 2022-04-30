using Features.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public class NewsManager : INewsManager
    {
        private readonly INewsService _newsService;
        public NewsManager(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<Article> AsyncCreateArticle(Article article)
        {
            //50k check
            throw new NotImplementedException();
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




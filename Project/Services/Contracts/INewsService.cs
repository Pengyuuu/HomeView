using Features.News;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managers.Implementations
{
    public interface INewsService
    {
        Task<Article> AsyncCreateArticle(Article article);
        Task<int> AsyncDeleteArticleById(int id);
        Task<Article> AsyncGetArticleById(int id);
        Task<IEnumerable<Article>> AsyncGetNews();
        Task<Article> AsyncUpdateArticleById(Article article);
    }
}
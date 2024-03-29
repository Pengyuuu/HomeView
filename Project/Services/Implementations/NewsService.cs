﻿using Features.News;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    /*
     * Go for reusability in the services
     * validate and deserialize (-> object) in here
     */
    public class NewsService : INewsService
    {

        private readonly NewsDAO _newsDAO;
        public NewsService(NewsDAO dao)
        {
            _newsDAO = dao;
        }

        /* returns null if failed to create article in db */
        public async Task<Article> AsyncCreateArticle(Article article)
        {
            if (await _newsDAO.AsyncCreateArticle(article) != 1)
            {
                return null;
            }
            IEnumerable<Article> articles =  await AsyncGetNews();
            return articles.LastOrDefault();
        }

        /* will return a null Article if not found */
        /*
         * no need for null check, instead check length of arr
         */
        public async Task<Article> AsyncGetArticleById(int id)
        {
            var res = await _newsDAO.AsyncReadArticles(id);
            if (res != null)
            {
                return res.FirstOrDefault();
            }
            return null;
        }

        /* returns all news articles in the db */
        public async Task<IEnumerable<Article>> AsyncGetNews()
        {
            return await _newsDAO.AsyncReadArticles();
        }

        /* Updates an article,
         * the article DTO must have the id of article to be updated */
        public async Task<Article> AsyncUpdateArticleById(Article article)
        {
            if (await _newsDAO.AsyncUpdateArticle(article) != 1)
            {
                return null;
            }
            var res = await _newsDAO.AsyncReadArticles(article.ArticleId);
            return res.FirstOrDefault();
        }

        /* Deletes an Article
         * Returns 0 if failed (0 rows affected), 1 for success */
        public async Task<int> AsyncDeleteArticleById(int id)
        {
            int ret = await _newsDAO.AsyncDeleteArticle(id);
            if (ret != 0)
            {
                return ret;
            }
            return 0;
        }

        public async Task<int> AsyncGetNewsDateCount(DateTime date)
        {
            return await _newsDAO.AsyncGetNewsCount(date);          
        }
    }
}




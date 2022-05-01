
using System;
using System.Threading.Tasks;

namespace Features.News
{
    /* Article DTO, matching properties to DB Cols */
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string ImgPath { get; set; }
        public DateTime publishDate { get; set; }

        public Article(string articleTitle, string articleContent, string imgPath)
        { 
            ArticleTitle = articleTitle;
            ArticleContent = articleContent;
            ImgPath = imgPath;
        }

        public Article() { }
    }


}

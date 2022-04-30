
namespace Features.News
{
    /* Article DTO, matching properties to DB Cols */
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleContent { get; set; }
        public string ImgPath { get; set; }

    }


}

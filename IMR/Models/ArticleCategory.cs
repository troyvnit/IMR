using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class ArticleCategory
    {
        public int ArticleCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
        public int MainArticleId { get; set; }
        public Article MainArticle { get; set; }
    }
}
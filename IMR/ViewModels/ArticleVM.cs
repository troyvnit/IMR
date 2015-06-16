using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.ViewModels
{
    public class ArticleVM
    {
        public int ArticleId { get; set; }
        public string Avatar { get; set; }
        public string SeoTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ICollection<ArticleVM> RelatedArticles { get; set; }
    }
}
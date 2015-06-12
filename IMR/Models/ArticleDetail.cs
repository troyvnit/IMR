using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class ArticleDetail
    {
        public int ArticleDetailId { get; set; }
        public string SeoTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Language Language { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
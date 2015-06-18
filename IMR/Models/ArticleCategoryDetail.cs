using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class ArticleCategoryDetail
    {
        public int ArticleCategoryDetailId { get; set; }
        public string Name { get; set; }
        public Language Language { get; set; }
        public int ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Areas.BO.Models
{
    public class ArticleCategoryBO
    {
        public int ArticleCategoryId { get; set; }
        public string Name { get; set; }
        public int MainArticleId { get; set; }
    }
}
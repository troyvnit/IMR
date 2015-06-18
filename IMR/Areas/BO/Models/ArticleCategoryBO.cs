using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Areas.BO.Models
{
    public class ArticleCategoryBO
    {
        public int ArticleCategoryId { get; set; }
        public int CategoryIdEn { get; set; }
        public string NameEn { get; set; }
        public int CategoryIdDe { get; set; }
        public string NameDe { get; set; }
        public int CategoryIdVi { get; set; }
        public string NameVi { get; set; }
        public int MainArticleId { get; set; }
    }
}
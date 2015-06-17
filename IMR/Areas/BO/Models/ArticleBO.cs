using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Areas.BO.Models
{
    public class ArticleBO
    {
        public int ArticleId { get; set; }
        public string Avatar { get; set; }
        public int IdEn { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionEn { get; set; }
        public string ContentEn { get; set; }
        public int IdDe { get; set; }
        public string TitleDe { get; set; }
        public string DescriptionDe { get; set; }
        public string ContentDe { get; set; }
        public int IdVi { get; set; }
        public string TitleVi { get; set; }
        public string DescriptionVi { get; set; }
        public string ContentVi { get; set; }
        public int ArticleCategoryId { get; set; }
        public string IsMain { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Avatar { get; set; }
        public ICollection<ArticleDetail> ArticleDetails { get; set; }
        public int ArticleCategoryId { get; set; }
        public ArticleCategory ArticleCategory { get; set; }
    }
}
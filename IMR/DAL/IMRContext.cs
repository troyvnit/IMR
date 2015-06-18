using IMR.Models;
using IMR.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMR.DAL
{
    public class IMRContext : DbContext
    {
        public IMRContext()
            : base("IMRContext")
        {
        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleCategoryDetail> ArticleCategoryDetails { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDetail> ArticleDetails { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingDetail> SettingDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleMap());
        }
    }
}
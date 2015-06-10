using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace IMR.Models.Mapping
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
            HasMany(a => a.RelatedArticles).WithMany().Map(x => 
            {
                x.MapLeftKey("Article_ArticleId");
                x.MapRightKey("Article_ArticleId1");
                x.ToTable("Article_RelatedArticles");
            });
        }
    }
}
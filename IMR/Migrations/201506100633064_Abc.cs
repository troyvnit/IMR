namespace IMR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleDetails",
                c => new
                    {
                        ArticleDetailId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        Language = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleDetailId)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Avatar = c.String(),
                        Menu_MenuId = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Menus", t => t.Menu_MenuId)
                .Index(t => t.Menu_MenuId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.Article_RelatedArticles",
                c => new
                    {
                        Article_ArticleId = c.Int(nullable: false),
                        Article_ArticleId1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Article_ArticleId, t.Article_ArticleId1 })
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId)
                .ForeignKey("dbo.Articles", t => t.Article_ArticleId1)
                .Index(t => t.Article_ArticleId)
                .Index(t => t.Article_ArticleId1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Menu_MenuId", "dbo.Menus");
            DropForeignKey("dbo.Article_RelatedArticles", "Article_ArticleId1", "dbo.Articles");
            DropForeignKey("dbo.Article_RelatedArticles", "Article_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ArticleDetails", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Article_RelatedArticles", new[] { "Article_ArticleId1" });
            DropIndex("dbo.Article_RelatedArticles", new[] { "Article_ArticleId" });
            DropIndex("dbo.Articles", new[] { "Menu_MenuId" });
            DropIndex("dbo.ArticleDetails", new[] { "ArticleId" });
            DropTable("dbo.Article_RelatedArticles");
            DropTable("dbo.Menus");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleDetails");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IMR.DAL;
using IMR.Models;
using IMR.Models.Enums;
using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.Utils;

namespace IMR.Areas.BO.Controllers
{
    [Authorize]
    public class ArticleBOController : Controller
    {
        private IMRContext db = new IMRContext();

        // GET: BO/ArticleBO
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.ArticleDetails).ToList();
            return View(articles.Select(a => Mapper.Map<ArticleBO>(a)));
        }

        // GET: BO/ArticleBO/Create
        public ActionResult Create(int? id)
        {
            var articleCategories = db.ArticleCategories.Include(ac => ac.ArticleCategoryDetails).ToList();
            ViewBag.ArticleCategories = articleCategories.Select(ac => Mapper.Map<ArticleCategoryBO>(ac));
            if (id == null)
            {
                return View(new ArticleBO { Avatar = "no-avatar.jpg" });
            }
            Article article = db.Articles.Include(a => a.ArticleDetails).Include(a => a.ArticleCategory).FirstOrDefault(a => a.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var articleBO = Mapper.Map<ArticleBO>(article);
            articleBO.IsMain = article.ArticleCategory.MainArticleId == article.ArticleId ? "checked" : "";
            return View(articleBO);
        }

        // POST: BO/ArticleBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleBO articleBO, HttpPostedFileBase AvatarFile)
        {
            var article = Mapper.Map<Article>(articleBO);
            article.ArticleDetails = new List<ArticleDetail> { 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdEn, Language = Language.En, SeoTitle = articleBO.TitleEn.GenerateSeoTitle(), Title = articleBO.TitleEn, Description = articleBO.DescriptionEn, Content = articleBO.ContentEn }, 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdDe, Language = Language.De, SeoTitle = articleBO.TitleDe.GenerateSeoTitle(), Title = articleBO.TitleDe, Description = articleBO.DescriptionDe, Content = articleBO.ContentDe }, 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdVi, Language = Language.Vi, SeoTitle = articleBO.TitleVi.GenerateSeoTitle(), Title = articleBO.TitleVi, Description = articleBO.DescriptionVi, Content = articleBO.ContentVi }
                };
            if (AvatarFile != null && AvatarFile.ContentLength > 0)
            {
                string path = "~/img/" + AvatarFile.FileName;
                AvatarFile.SaveAs(Server.MapPath(path));
                article.Avatar = AvatarFile.FileName;
            }
            var articleCategory = db.ArticleCategories.FirstOrDefault(ac => ac.ArticleCategoryId == articleBO.ArticleCategoryId);
            if (articleCategory != null)
            {
                article.ArticleCategoryId = articleCategory.ArticleCategoryId;
                article.ArticleCategory = articleCategory;
            }
            if (article.ArticleId != 0)
            {
                db.Entry(article).State = EntityState.Modified;
                foreach (var articleDetail in article.ArticleDetails)
                {
                    db.Entry(articleDetail).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            else
            {
                db.Articles.Add(article);
                db.SaveChanges();
            }
            if (articleBO.IsMain == "on")
            {
                articleCategory.MainArticleId = article.ArticleId;
                db.Entry(articleCategory).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: BO/ArticleBO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: BO/ArticleBO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetArticles(string query, int ArticleId)
        {
            return Json(db.Articles.Where(a => a.ArticleDetails.Count(ad => ad.Title.Contains(query)) > 0 && a.ArticleId != ArticleId).Select(a => new { a.ArticleId, 
                Title = a.ArticleDetails.FirstOrDefault(ad => ad.Language == Language.En) != null ? 
                a.ArticleDetails.FirstOrDefault(ad => ad.Language == Language.En).Title : "" 
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateCategory(ArticleCategoryBO articleCategoryBO){
            var articleCategory = Mapper.Map<ArticleCategory>(articleCategoryBO);
            articleCategory.ArticleCategoryDetails = new List<ArticleCategoryDetail> { 
                    new ArticleCategoryDetail { ArticleCategoryId = articleCategoryBO.ArticleCategoryId, ArticleCategoryDetailId = articleCategoryBO.CategoryIdEn, Language = Language.En, Name = articleCategoryBO.NameEn }, 
                    new ArticleCategoryDetail { ArticleCategoryId = articleCategoryBO.ArticleCategoryId, ArticleCategoryDetailId = articleCategoryBO.CategoryIdDe, Language = Language.De, Name = articleCategoryBO.NameDe }, 
                    new ArticleCategoryDetail { ArticleCategoryId = articleCategoryBO.ArticleCategoryId, ArticleCategoryDetailId = articleCategoryBO.CategoryIdVi, Language = Language.Vi, Name = articleCategoryBO.NameVi }
                };
            if (articleCategory.ArticleCategoryId != 0)
            {
                db.Entry(articleCategory).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.ArticleCategories.Add(articleCategory);
                db.SaveChanges();
            }
            return Json(Mapper.Map<ArticleCategoryBO>(articleCategory), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

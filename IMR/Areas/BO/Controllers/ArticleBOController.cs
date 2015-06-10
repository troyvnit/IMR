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

namespace IMR.Areas.BO.Controllers
{
    public class ArticleBOController : Controller
    {
        private IMRContext db = new IMRContext();

        // GET: BO/ArticleBO
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.ArticleDetails).Include(a => a.RelatedArticles).ToList();
            return View(articles.Select(a => Mapper.Map<ArticleBO>(a)));
        }

        // GET: BO/ArticleBO/Details/5
        public ActionResult Details(int? id)
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

        // GET: BO/ArticleBO/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return View(new ArticleBO { Avatar = "no-avatar.jpg" });
            }
            Article article = db.Articles.Include(a => a.ArticleDetails).Include(a => a.RelatedArticles).Include(a => a.RelatedArticles.Select(ra => ra.ArticleDetails)).FirstOrDefault(a => a.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ArticleBO>(article));
        }

        // POST: BO/ArticleBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleBO articleBO, HttpPostedFileBase AvatarFile)
        {
            if (ModelState.IsValid)
            {
                var article = Mapper.Map<Article>(articleBO);
                article.ArticleDetails = new List<ArticleDetail> { 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdEn, Language = Language.En, Title = articleBO.TitleEn, Description = articleBO.DescriptionEn, Content = articleBO.ContentEn }, 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdDe, Language = Language.De, Title = articleBO.TitleDe, Description = articleBO.DescriptionDe, Content = articleBO.ContentDe }, 
                    new ArticleDetail { ArticleId = articleBO.ArticleId, ArticleDetailId = articleBO.IdVi, Language = Language.Vi, Title = articleBO.TitleVi, Description = articleBO.DescriptionVi, Content = articleBO.ContentVi }
                };
                if (AvatarFile != null && AvatarFile.ContentLength > 0)
                {
                    string path = "~/img/" + AvatarFile.FileName;
                    AvatarFile.SaveAs(Server.MapPath(path));
                    article.Avatar = AvatarFile.FileName;
                }
                if (article.ArticleId != 0)
                {
                    db.Entry(article).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Articles.Add(article);
                    db.SaveChanges();
                }
                var savedArticle = db.Articles.Include(a => a.ArticleDetails).Include(a => a.RelatedArticles).FirstOrDefault(a => a.ArticleId == article.ArticleId);
                savedArticle.RelatedArticles = new List<Article>();
                if (!string.IsNullOrEmpty(articleBO.RelatedArticleIds))
                {
                    var relatedArticleIds = articleBO.RelatedArticleIds.Split(',');
                    foreach (var relatedArticleIdString in relatedArticleIds)
                    {
                        var relatedArticleId = int.Parse(relatedArticleIdString);
                        var relatedArticle = db.Articles.FirstOrDefault(a => a.ArticleId == relatedArticleId);
                        if (relatedArticle != null)
                        {
                            savedArticle.RelatedArticles.Add(relatedArticle);
                        }
                    }
                }
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleBO);
        }

        // GET: BO/ArticleBO/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: BO/ArticleBO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleId,Avatar")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
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

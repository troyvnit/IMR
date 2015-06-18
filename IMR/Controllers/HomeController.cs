using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.DAL;
using IMR.Models.Enums;
using IMR.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMR.Controllers
{
    public class HomeController : BaseController
    {
        private IMRContext db = new IMRContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Article(string category, string seoTitle)
        {
            var articleCategory = db.ArticleCategories.Include(ac => ac.Articles).FirstOrDefault(ac => ac.ArticleCategoryDetails.Count(acd => acd.Name == category) > 0);
            var article = !string.IsNullOrEmpty(seoTitle) ? 
                db.Articles.Include(a => a.ArticleDetails).FirstOrDefault(a => a.ArticleDetails.Count(ad => ad.SeoTitle == seoTitle) > 0) :
                articleCategory != null ? db.Articles.Include(a => a.ArticleDetails).FirstOrDefault(a => a.ArticleId == articleCategory.MainArticleId) : null;
            if (article == null)
            {
                return HttpNotFound();
            }
            var sameCategoryArticles = db.Articles.Include(a => a.ArticleDetails).Where(a => a.ArticleCategoryId == articleCategory.ArticleCategoryId && a.ArticleId != articleCategory.MainArticleId).ToList();
            ViewBag.SameCategoryArticles = sameCategoryArticles.Select(Mapper.Map<ArticleVM>).ToList();
            ViewBag.CategoryName = category;
            return View(Mapper.Map<ArticleVM>(article));
        }

        public ActionResult _Menu()
        {
            var currentCategory = Request.RequestContext.RouteData.Values["category"];
            var currentSeoTitle = Request.RequestContext.RouteData.Values["seoTitle"];
            var category = db.ArticleCategories.Include(ac => ac.ArticleCategoryDetails).FirstOrDefault(ac => ac.ArticleCategoryDetails.Count(acd => acd.Name == currentCategory) > 0);
            var article = db.Articles.Include(a => a.ArticleDetails).FirstOrDefault(a => a.ArticleDetails.Count(ad => ad.SeoTitle == currentSeoTitle) > 0);
            var enUrl = "/en";
            var deUrl = "/de";
            var viUrl = "/vi";
            if(category != null){
                enUrl += "/a/" + category.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.En).Name;
                deUrl += "/a/" + category.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.De).Name;
                viUrl += "/a/" + category.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.Vi).Name;
            }
            if(article != null){
                enUrl += "/" + article.ArticleDetails.FirstOrDefault(a => a.Language == Language.En).SeoTitle;
                deUrl += "/" + article.ArticleDetails.FirstOrDefault(a => a.Language == Language.De).SeoTitle;
                viUrl += "/" + article.ArticleDetails.FirstOrDefault(a => a.Language == Language.Vi).SeoTitle; 
            }
            ViewBag.EnUrl = enUrl;
            ViewBag.DeUrl = deUrl;
            ViewBag.ViUrl = viUrl; 
            var articleCategories = db.ArticleCategories.Include(ac => ac.ArticleCategoryDetails).ToList();
            return PartialView(articleCategories.Select(Mapper.Map<ArticleCategoryVM>).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
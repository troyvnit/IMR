using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.DAL;
using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMR.Controllers
{
    public class HomeController : Controller
    {
        private IMRContext db = new IMRContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Article(string seoTitle)
        {
            var article = db.Articles.Include(a => a.ArticleDetails).Include(a => a.RelatedArticles).FirstOrDefault(a => a.ArticleDetails.FirstOrDefault(ad => ad.Language == Language.En).SeoTitle == seoTitle);
            return View(Mapper.Map<ArticleBO>(article));
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
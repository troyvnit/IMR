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

        public ActionResult Article(string seoTitle)
        {
            var article = db.Articles.Include(a => a.ArticleDetails).FirstOrDefault(a => a.ArticleDetails.Count(ad => ad.SeoTitle == seoTitle) > 0);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ArticleVM>(article));
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
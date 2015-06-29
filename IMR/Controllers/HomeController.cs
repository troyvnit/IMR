using AutoMapper;
using IMR.Areas.BO.Models;
using IMR.DAL;
using IMR.Models.Enums;
using IMR.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IMR.Controllers
{
    public class HomeController : BaseController
    {
        private IMRContext db = new IMRContext();
        public ActionResult Index()
        {
            var mainBoxSettings = db.SettingDetails.Where(sd => sd.Setting.SettingType == SettingType.HomePage_MainBox && Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(sd.Language.ToString().ToLower())).ToList();
            ViewBag.MainBoxSettings = mainBoxSettings.Select(Mapper.Map<SettingVM>);
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
            var contact = Request.RequestContext.RouteData.Values["contact"];
            if (contact != null)
            {
                enUrl += "/" + Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("en"));
                deUrl += "/" + Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("de"));
                viUrl += "/" + Resources.IMRResources.ResourceManager.GetString("Contact", CultureInfo.CreateSpecificCulture("vi")); 
            }
            ViewBag.EnUrl = enUrl;
            ViewBag.DeUrl = deUrl;
            ViewBag.ViUrl = viUrl; 
            var articleCategories = db.ArticleCategories.Include(ac => ac.ArticleCategoryDetails).ToList();
            return PartialView(articleCategories.Select(Mapper.Map<ArticleCategoryVM>).ToList());
        }

        public ActionResult _Header()
        {
            var sloganSetting = db.SettingDetails.FirstOrDefault(sd => sd.Setting.SettingType == SettingType.Layout_Header_Slogan && Thread.CurrentThread.CurrentUICulture.Name.ToLower().Contains(sd.Language.ToString().ToLower()));
            ViewBag.Slogan = sloganSetting != null ? sloganSetting.Description : "";
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactVM contactForm)
        {
            var body = "<p>Email From: {0} ({1})</p>{3}{4}{5}{6}{7}{8}{9}<p>Message:</p><p>{2}</p>";
            var firm = !string.IsNullOrEmpty(contactForm.Firm) ? "<p>Firm:</p><p>" + contactForm.Firm + "</p>" : "";
            var street = !string.IsNullOrEmpty(contactForm.Street) ? "<p>Street:</p><p>" + contactForm.Street + "</p>" : "";
            var postcode = !string.IsNullOrEmpty(contactForm.Postcode) ? "<p>Postcode:</p><p>" + contactForm.Postcode + "</p>" : "";
            var town = !string.IsNullOrEmpty(contactForm.Town) ? "<p>Town:</p><p>" + contactForm.Town + "</p>" : "";
            var telephoneNumber = !string.IsNullOrEmpty(contactForm.TelephoneNumber) ? "<p>Telephone Number:</p><p>" + contactForm.TelephoneNumber + "</p>" : "";
            var freeTrial = "<p>Free trial:</p><p>" + (contactForm.FreeTrial ? "Yes" : "No") + "</p>";
            var callback = "<p>Callback:</p><p>" + (contactForm.Callback ? "Yes" : "No") + "</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("troyuit@gmail.com"));  
            message.From = new MailAddress(contactForm.EmailAddress);  
            message.Subject = contactForm.Subject;
            message.Body = string.Format(body, contactForm.ContactPerson, contactForm.EmailAddress, contactForm.Message, firm, street, postcode, town, telephoneNumber, freeTrial, callback);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "troyuit@gmail.com",  
                    Password = "triphuong18092008"  
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return View(contactForm);
            }
        }
    }
}
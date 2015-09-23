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
    public class SettingBOController : Controller
    {
        private IMRContext db = new IMRContext();

        // GET: BO/SettingBO
        public ActionResult Index()
        {
            var settings = db.Settings.Include(a => a.SettingDetails).ToList();
            return View(settings.Select(a => Mapper.Map<SettingBO>(a)));
        }

        // GET: BO/SettingBO/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return View(new SettingBO { Avatar = "no-avatar.jpg" });
            }
            Setting setting = db.Settings.Include(a => a.SettingDetails).FirstOrDefault(a => a.SettingId == id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<SettingBO>(setting));
        }

        // POST: BO/SettingBO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SettingBO settingBO, HttpPostedFileBase AvatarFile)
        {
            if (ModelState.IsValid)
            {
                var setting = Mapper.Map<Setting>(settingBO);
                setting.SettingDetails = new List<SettingDetail> { 
                    new SettingDetail { SettingId = settingBO.SettingId, SettingDetailId = settingBO.IdEn, Language = Language.En, Name = settingBO.NameEn, Description = settingBO.DescriptionEn, Link = settingBO.LinkEn }, 
                    new SettingDetail { SettingId = settingBO.SettingId, SettingDetailId = settingBO.IdDe, Language = Language.De, Name = settingBO.NameDe, Description = settingBO.DescriptionDe, Link = settingBO.LinkDe }, 
                    new SettingDetail { SettingId = settingBO.SettingId, SettingDetailId = settingBO.IdVi, Language = Language.Vi, Name = settingBO.NameVi, Description = settingBO.DescriptionVi, Link = settingBO.LinkVi }
                };
                if (AvatarFile != null && AvatarFile.ContentLength > 0)
                {
                    string path = "~/img/" + AvatarFile.FileName;
                    AvatarFile.SaveAs(Server.MapPath(path));
                    setting.Avatar = AvatarFile.FileName;
                }
                if (setting.SettingId != 0)
                {
                    db.Entry(setting).State = EntityState.Modified;
                    foreach (var settingDetail in setting.SettingDetails)
                    {
                        db.Entry(settingDetail).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                else
                {
                    db.Settings.Add(setting);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(settingBO);
        }

    }
}
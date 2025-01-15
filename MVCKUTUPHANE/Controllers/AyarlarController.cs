using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class AyarlarController : Controller
    {
        // GET: Ayarlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var users = db.TBLADMIN.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLADMIN p)
        {
            db.TBLADMIN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            db.TBLADMIN.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBLADMIN.Find(id);
            return View("AdminGuncelle",admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN p)
        {
            var admin = db.TBLADMIN.Find(p.ID);
            admin.Kullanici=p.Kullanici;
            admin.Sifre=p.Sifre;
            admin.Yetki=p.Yetki;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
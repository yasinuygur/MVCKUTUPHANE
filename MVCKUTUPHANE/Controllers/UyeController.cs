using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa =1)
        {
            //var values = db.TBLUYE.ToList();
            var values = db.TBLUYE.ToList().ToPagedList(sayfa,3);
            return View(values);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYE p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYE.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYE p)
        {
            var uye = db.TBLUYE.Find(p.ID);
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.AD=p.AD;
            uye.MAIL=p.MAIL;
            uye.OKUL=p.OKUL;
            uye.FOTOGRAF=p.FOTOGRAF;
            uye.SIFRE=p.SIFRE;
            uye.TELEFON=p.TELEFON;
            uye.SOYAD=p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYE.Find(id);
            db.TBLUYE.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var kitapGecmis = db.TBLHAREKET.Where(x=>x.UYE==id).ToList();
            var uyeKitap= db.TBLUYE.Where(u=>u.ID==id).Select(u=>u.AD+" "+u.SOYAD).FirstOrDefault();
            ViewBag.uye=uyeKitap;
            return View(kitapGecmis);
        }
    }
}
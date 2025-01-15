using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKUTUPHANE.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {
        // GET: Paneli
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var uyeMail= (string)Session["Mail"];
            //var degerler = db.TBLUYE.FirstOrDefault(z=>z.MAIL==uyeMail);
            var degerler=db.TBLDUYURU.ToList();
            var d1 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.AD).FirstOrDefault();
            ViewBag.d1 = d1;

            var d2 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;

            var d3 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.FOTOGRAF).FirstOrDefault();
            ViewBag.d3 = d3;

            var d4 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.KULLANICIADI).FirstOrDefault();
            ViewBag.d4 = d4;

            var d5 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;

            var d6 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;

            var d7 = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;

            var uyeID = db.TBLUYE.Where(x => x.MAIL == uyeMail).Select(x => x.ID).FirstOrDefault();
            var d8 = db.TBLHAREKET.Where(x => x.UYE == uyeID).Count();
            ViewBag.d8 = d8;

            var d9 = db.TBLMESAJLAR.Where(x => x.ALICI == uyeMail).Count();
            ViewBag.d9 = d9;

            var d10 = db.TBLDUYURU.Count();
            ViewBag.d10 = d10;
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYE p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYE.FirstOrDefault(x=>x.MAIL==kullanici);
            uye.SIFRE=p.SIFRE;
            uye.AD=p.AD;
            uye.SOYAD=p.SOYAD;
            uye.KULLANICIADI=p.KULLANICIADI;
            uye.FOTOGRAF=p.FOTOGRAF;
            uye.OKUL=p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id=db.TBLUYE.Where(x=>x.MAIL==kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult Duyurular()
        {
            var duyuruListesi = db.TBLDUYURU.ToList();
            return View(duyuruListesi);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYE.Where(x => x.MAIL == kullanici).Select(x => x.ID).FirstOrDefault();
            var uyeBul = db.TBLUYE.Find(id);
            return PartialView("Partial2", uyeBul);
        }
    }
}
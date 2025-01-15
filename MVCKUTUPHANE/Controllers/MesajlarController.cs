using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x=>x.ALICI==uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult GidenMesaj()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN=uyemail.ToString();
            t.TARIH=DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj","Mesajlar");
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelenSayisi = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelenSayisi;
            var gidenSayisi = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidenSayisi;
            return PartialView();
        }
    }
}
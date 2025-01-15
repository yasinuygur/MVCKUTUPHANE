using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.TBLYAZAR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddYazar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddYazar(TBLYAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.TBLYAZAR.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBLYAZAR p)
        {
            var yzr = db.TBLYAZAR.Find(p.ID);
            yzr.AD=p.AD;
            yzr.SOYAD=p.SOYAD;
            yzr.DETAY=p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBLKITAP.Where(x => x.YAZAR == id).ToList();
            var yazarAd = db.TBLYAZAR.Where(x=>x.ID == id).Select(x=>x.AD+" "+x.SOYAD).FirstOrDefault();
            ViewBag.yazar = yazarAd;
            return View(yazar);
        }
    }
}
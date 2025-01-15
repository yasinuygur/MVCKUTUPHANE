using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURU.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURU d)
        {
            db.TBLDUYURU.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURU.Find(id);
            db.TBLDUYURU.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBLDUYURU d)
        {
            var duyuru = db.TBLDUYURU.Find(d.ID);
            return View("DuyuruDetay", duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURU d)
        {
            var duyuru = db.TBLDUYURU.Find(d.ID);
            duyuru.TARIH = d.TARIH;
            duyuru.KATEGORI = d.KATEGORI;
            duyuru.ICERIK=d.ICERIK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
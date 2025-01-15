using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKUTUPHANEEntities db= new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.TBLPERSONEL.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var personel = db.TBLPERSONEL.Find(p.ID);
            personel.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
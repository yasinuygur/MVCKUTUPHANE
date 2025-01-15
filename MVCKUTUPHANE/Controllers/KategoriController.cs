using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = db.TBLKATEGORI.Where(x=>x.DURUM==true).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TBLKATEGORI p)
        {
            db.TBLKATEGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult GetCategory(int id)
        {
            var category = db.TBLKATEGORI.Find(id);
            return View("GetCategory",category);
        }
        public ActionResult EditCategory(TBLKATEGORI p)
        {
            var category = db.TBLKATEGORI.Find(p.ID);
            category.AD=p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id) 
        {
            var category = db.TBLKATEGORI.Find(id);
           // db.TBLKATEGORI.Remove(category);
           category.DURUM=false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
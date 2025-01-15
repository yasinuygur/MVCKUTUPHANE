using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYE.Count();
            var deger2 = db.TBLKITAP.Count();
            var deger3 = db.TBLKITAP.Where(x=>x.DURUM==false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x=>x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFile dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string yol = Path.Combine(Server.MapPath("~/web2/resimler"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(yol);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKITAP.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBLUYE.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBLCEZALAR.Sum(x=>x.PARA);
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBLKITAP.Where(x => x.DURUM==false).Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.TBLKATEGORI.Count();
            ViewBag.dgr5 = deger5;

            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8=deger8;
            var deger9 = db.TBLKITAP.GroupBy(x=>x.YAYINEVI).OrderByDescending(z=>z.Count()).Select(y=>new {y.Key}).FirstOrDefault();
            ViewBag.dgr9 = deger9;

            var deger11 = db.TBLILETISIM.Count();
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}
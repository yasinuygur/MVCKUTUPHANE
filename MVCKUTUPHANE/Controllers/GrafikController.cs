using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKUTUPHANE.Models;

namespace MVCKUTUPHANE.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Güneş Yayınevi",
                sayi=7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Yıldız Yayınevi",
                sayi = 10
            });
            cs.Add(new Class1()
            {
                yayinevi = "Dünya Yayınevi",
                sayi = 18
            });
            return cs;
        }
    }
}
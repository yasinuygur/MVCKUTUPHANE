using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBKUTUPHANEEntities db= new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN p)
        {
            var values = db.TBLADMIN.FirstOrDefault(x=>x.Kullanici==p.Kullanici&&x.Sifre==p.Sifre);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Kullanici, false);
                Session["Kullanici"] = values.Kullanici.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}
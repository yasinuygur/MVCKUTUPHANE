﻿using MVCKUTUPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKUTUPHANE.Controllers
{
    [AllowAnonymous]
    public class KayitController : Controller
    {
        // GET: Kayit
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLUYE p)
        {
            if(!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLUYE.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}
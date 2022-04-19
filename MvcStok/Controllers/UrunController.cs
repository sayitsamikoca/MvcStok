﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities dbStokEntities = new MvcDbStokEntities(); 
        public ActionResult Index()
        {
            var urunler = dbStokEntities.TBLURUNLER.ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER urun)
        {
            dbStokEntities.TBLURUNLER.Add(urun);
            dbStokEntities.SaveChanges();
            return View();
        }
    }
}
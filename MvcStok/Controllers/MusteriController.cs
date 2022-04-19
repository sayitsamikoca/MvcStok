using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities dbStokEntities = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var musteriler = dbStokEntities.TBLMUSTERILER.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER musteri)
        {
            dbStokEntities.TBLMUSTERILER.Add(musteri);
            dbStokEntities.SaveChanges(); // Değişiklikleri Kayıt Et.
            return View();
        }
    }
}
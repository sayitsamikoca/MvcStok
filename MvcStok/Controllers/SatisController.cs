using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbStokEntities dbStokEntities = new MvcDbStokEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();

        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR satis)
        {
            dbStokEntities.TBLSATISLAR.Add(satis);
            dbStokEntities.SaveChanges();
            return View("Index");
        }
    }
}
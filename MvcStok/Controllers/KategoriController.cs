using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity; // Models altındaki entity klasörüne ulaşbilmek için, kütüphane olarak tanımladım.

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities dbStokEntities = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var kategoriler = dbStokEntities.TBLKATEGORILER.ToList(); // Kategoriler listesindeki değerleri listele

            return View(kategoriler); // bana kategorileri döndür.
            
        }
    }
}
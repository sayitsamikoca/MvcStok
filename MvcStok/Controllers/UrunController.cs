using System;
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
            // LINQ İle sorgulama yaptık - DropdownList için db'den veri seçme [Ürün ekleme yaparken kullanacağız.]
            List<SelectListItem> degerler = (from i in dbStokEntities.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler; // Controller tarafındaki ifadeyi diğer tarafa taşıyacağız - nesne türetip orada kullanacağız.

            return View();
        }


        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER urun)
        {   // firstOrDefault : Seçmiş Olduğum İlk Değeri getir.
            var kategori = dbStokEntities.TBLKATEGORILER.Where(m=> m.KATEGORIID == urun.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            
            urun.TBLKATEGORILER = kategori;

            dbStokEntities.TBLURUNLER.Add(urun);
            dbStokEntities.SaveChanges();
            return RedirectToAction("Index"); // Kayıt etme işi tamamlanınca Index sayfasına geri döndür
        }

        public ActionResult UrunSil(int id)
        {
            var urun = dbStokEntities.TBLURUNLER.Find(id);
            dbStokEntities.TBLURUNLER.Remove(urun);
            dbStokEntities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id) // Ürün Bilgilerini Taşıma.
        {
            var urun = dbStokEntities.TBLURUNLER.Find(id);
            return View("UrunGetir", urun);  //ÜrünGetir'i döndür, bunun içinde|beraberinde değeri urun olacak.

        }
    }
}
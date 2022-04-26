using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList; // paging işlemleri için framework tanımladım an .Mvc
using PagedList.Mvc;
using System.Web.Mvc;
using MvcStok.Models.Entity; // Models altındaki entity klasörüne ulaşbilmek için, kütüphane olarak tanımladım.

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities dbStokEntities = new MvcDbStokEntities();
        public ActionResult Index(int page = 1)
        {
            // var kategoriler = dbStokEntities.TBLKATEGORILER.ToList(); // Kategoriler listesindeki değerleri listele

            var kategoriler = dbStokEntities.TBLKATEGORILER.ToList().ToPagedList(page, 4); // page 1'den başla ve her sayfada 4 tane göster.
            return View(kategoriler); // bana kategorileri döndür.
            
        }


        [HttpGet] // eğerki sayfa ilk yükleniyorsa, bir işlem yoksa sadece view'i geri döndür
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost] // sayfaya herhangi bir post işlemi yapıldığı zaman:
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                // Modelin durumunda doğrulama işlemi yapılmadıysa içeriye gir:

                return View("YeniKategori"); // Aynız sayfayı döndür, zaten hata mesajı gözükecek döndüğünde:)

            }

            dbStokEntities.TBLKATEGORILER.Add(p1);
            dbStokEntities.SaveChanges(); // Değişiklikleri Kayıt et.
            return View();
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = dbStokEntities.TBLKATEGORILER.Find(id);
            dbStokEntities.TBLKATEGORILER.Remove(kategori);
            dbStokEntities.SaveChanges();

            return RedirectToAction("Index"); // İşlem bitince Index'e geri döndür.
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = dbStokEntities.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", kategori);

        }

        public ActionResult Guncelle(TBLKATEGORILER item)
        {
            var kategori = dbStokEntities.TBLKATEGORILER.Find(item.KATEGORIID);
            kategori.KATEGORIAD = item.KATEGORIAD;
            dbStokEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
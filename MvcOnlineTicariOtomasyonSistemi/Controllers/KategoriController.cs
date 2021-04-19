using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();
        public ActionResult Index()
        {  
            var degerler = context.Kategoris.ToList();
            return View(degerler);      //MVC'nin ActionResult'tan kalıtım alan ViewResult dönmesini sağlayan kod 
        }

        [HttpGet]
        public ActionResult KategoriEkle()      //Overload metotlarda sadece birine ters tıkla view eklemek ikisine de ekler
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");       //İşlemler bittikten sonra beni Index aksiyonuna yönlendir
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var updatedKategori = context.Kategoris.Find(kategori.KategoriId);
            updatedKategori.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
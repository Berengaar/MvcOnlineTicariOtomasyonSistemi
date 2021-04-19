using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(u => u.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from kategori in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = kategori.KategoriAd,
                                               Value = kategori.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            urun.Durum = true;
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var silinecekUrun = context.Uruns.Find(id);
            silinecekUrun.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from kategori in context.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = kategori.KategoriAd,
                                               Value = kategori.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var guncellenecekUrun = context.Uruns.Find(id);
            return View("UrunGetir", guncellenecekUrun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var guncellenecekUrun = context.Uruns.Find(urun.UrunId);
            guncellenecekUrun.AlisFiyat = urun.AlisFiyat;
            guncellenecekUrun.Durum = urun.Durum;
            guncellenecekUrun.KategoriId = urun.KategoriId;
            guncellenecekUrun.Marka = urun.Marka;
            guncellenecekUrun.SatisFiyat = urun.SatisFiyat;
            guncellenecekUrun.Stok = urun.Stok;
            guncellenecekUrun.UrunAd = urun.UrunAd;
            guncellenecekUrun.UrunGorsel = urun.UrunGorsel;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var urunler = context.Uruns.ToList();
            return View(urunler);
        }

    }
}
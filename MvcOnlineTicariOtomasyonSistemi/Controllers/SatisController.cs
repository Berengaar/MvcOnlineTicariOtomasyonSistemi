using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context context = new Context();
        public ActionResult Index()
        {
            var satislar = context.SatisHarekets.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from urun in context.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = urun.UrunAd,
                                               Value = urun.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from cari in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = cari.CariAd+ " "+ cari.CariSoyad,
                                               Value = cari.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from personel in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = personel.PersonelAd+" "+personel.PersonelSoyad,
                                               Value = personel.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satis)
        {
            satis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satis);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from urun in context.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = urun.UrunAd,
                                               Value = urun.UrunId.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from cari in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = cari.CariAd + " " + cari.CariSoyad,
                                               Value = cari.CariId.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from personel in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = personel.PersonelAd + " " + personel.PersonelSoyad,
                                               Value = personel.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var guncellenecekSatis = context.SatisHarekets.Find(id);
            return View("SatisGetir",guncellenecekSatis);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var guncellenecekSatis = context.SatisHarekets.Find(satisHareket.SatisId);
            guncellenecekSatis.PersonelId = satisHareket.PersonelId;
            guncellenecekSatis.CariId = satisHareket.CariId;
            guncellenecekSatis.PersonelId = satisHareket.PersonelId;
            guncellenecekSatis.Adet = satisHareket.Adet;
            guncellenecekSatis.Fiyat = satisHareket.Fiyat;
            guncellenecekSatis.ToplamTutar = satisHareket.ToplamTutar;
            guncellenecekSatis.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var satisDetay = context.SatisHarekets.Where(s => s.SatisId == id).ToList();
            return View(satisDetay);
        }
    }
}
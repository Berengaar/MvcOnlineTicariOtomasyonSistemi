using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class CarilerController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var cariler = context.Carilers.Where(c=>c.Durum==true).ToList();
            return View(cariler);
        }

        public ActionResult CariSil(int id)
        {
            var silinecekCari = context.Carilers.Find(id);
            silinecekCari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            cari.Durum = true;
            context.Carilers.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var cari = context.Carilers.Find(id);
            return View("CariGetir", cari);
        }

        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var guncellenecekCari = context.Carilers.Find(cari.CariId);
            guncellenecekCari.CariAd = cari.CariAd;
            guncellenecekCari.CariSoyad = cari.CariSoyad;
            guncellenecekCari.CariSehir = cari.CariSehir;
            guncellenecekCari.CariMail = cari.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var cariBilgisi = context.Carilers.Where(c => c.CariId == id).Select(c => c.CariAd + " " + c.CariSoyad).FirstOrDefault();
            ViewBag.cari = cariBilgisi;
            var satislar = context.SatisHarekets.Where(s => s.CariId == id).ToList();
            return View(satislar);
        }
    }
}
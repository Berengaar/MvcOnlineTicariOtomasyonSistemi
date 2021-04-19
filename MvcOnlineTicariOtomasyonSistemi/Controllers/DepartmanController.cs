using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var departmans = context.Departmans.Where(d=>d.Durum==true).ToList();
            return View(departmans);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var silinecekDepartman = context.Departmans.Find(id);
            silinecekDepartman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir", departman);

        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var guncellenecekDepartman = context.Departmans.Find(departman.DepartmanId);
            guncellenecekDepartman.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var detaylar = context.Personels.Where(p => p.DepartmanId == id).ToList();
            var departmanAd = context.Departmans.Where(d => d.DepartmanId == id).Select(ö => ö.DepartmanAd).FirstOrDefault();
            ViewBag.departmanAd = departmanAd;
            return View(detaylar);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var satislar = context.SatisHarekets.Where(s => s.PersonelId == id).ToList();
            var personelAdi = context.Personels
                .Where(p => p.PersonelId == id).Select(p => p.PersonelAd + " " + p.PersonelSoyad).FirstOrDefault();
            ViewBag.personelAdi = personelAdi;
            return View(satislar);
        }
       
    }

   
}
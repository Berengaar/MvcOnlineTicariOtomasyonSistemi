using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;
namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var personel = context.Personels.Where(p=>p.Durum==true).ToList();
            return View(personel);
        }

        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> deger1 = (from departman in context.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = departman.DepartmanAd,
                                               Value = departman.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(Personel personel)
        {
            personel.Durum = true;
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var silinecekPersonel = context.Personels.Find(id);
            silinecekPersonel.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from departman in context.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = departman.DepartmanAd,
                                               Value = departman.DepartmanId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var guncellenecekPersonel = context.Personels.Find(id);         
            return View("PersonelGetir",guncellenecekPersonel);
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            var guncellenecekPersonel = context.Personels.Find(personel.PersonelId);
            guncellenecekPersonel.PersonelAd = personel.PersonelAd;
            guncellenecekPersonel.PersonelSoyad = personel.PersonelSoyad;
            guncellenecekPersonel.PersonelGorsel = personel.PersonelGorsel;
            guncellenecekPersonel.DepartmanId = personel.DepartmanId;
            guncellenecekPersonel.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
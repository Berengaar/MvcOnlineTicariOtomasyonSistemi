using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context context = new Context();
        public ActionResult Index()
        {
            var faturalar = context.Faturalars.ToList();
            return View(faturalar);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var guncellenecekFatura = context.Faturalars.Find(id);
            return View("FaturaGetir", guncellenecekFatura);
        }

        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var guncellenecekFatura = context.Faturalars.Find(fatura.FaturaId);
            guncellenecekFatura.FaturaSeriNo = fatura.FaturaSeriNo;
            guncellenecekFatura.FaturaSıraNo = fatura.FaturaSıraNo;
            guncellenecekFatura.Saat = fatura.Saat;
            guncellenecekFatura.Tarih = fatura.Tarih;
            guncellenecekFatura.TeslimAlan = fatura.TeslimAlan;
            guncellenecekFatura.TeslimEden = fatura.TeslimEden;
            guncellenecekFatura.VergiDairesi = fatura.VergiDairesi;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult FaturaDetay(int id)
        {
            var detaylar = context.FaturaKalems.Where(f => f.FaturaId == id).ToList();
            var teslimBilgisi = context.Faturalars.Where(f => f.FaturaId == id).Select(f => f.TeslimEden + " ---> " + f.TeslimAlan).
                SingleOrDefault();
            ViewBag.dgr1 = teslimBilgisi;
            return View(detaylar);
        }
        [HttpGet]
        public ActionResult FaturaKalemGirisi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalemGirisi(FaturaKalem faturaKalem)
        {
            var yeniKalem = context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
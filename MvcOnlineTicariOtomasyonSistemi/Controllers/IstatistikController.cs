using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyonSistemi.Controllers
{

    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context context = new Context();
        public ActionResult Index()
        {
            var deger1 = context.Carilers.Count().ToString();
            ViewBag.dgr1 = deger1;

            var deger2 = context.Uruns.Count().ToString();
            ViewBag.dgr2 = deger2;

            var deger3 = context.Personels.Count().ToString();
            ViewBag.dgr3 = deger3;

            var deger4 = context.Kategoris.Count().ToString();
            ViewBag.dgr4 = deger4;

            var deger5 = context.Uruns.Sum(u => u.Stok).ToString();
            ViewBag.dgr5 = deger5;

            var deger6 = (from urun in context.Uruns select urun.Marka).Distinct().Count().ToString();  //Distinct = Tekrarsız
            ViewBag.dgr6 = deger6;

            var deger7 = context.Uruns.Count(u => u.Stok < 20).ToString();
            ViewBag.dgr7 = deger7;

            var deger8 = (from urun in context.Uruns orderby urun.SatisFiyat descending select urun.UrunAd).FirstOrDefault();
            ViewBag.dgr8 = deger8;

            var deger9 = (from urun in context.Uruns orderby urun.SatisFiyat ascending select urun.UrunAd).FirstOrDefault();
            ViewBag.dgr9 = deger9;

            var deger10 = context.Uruns.GroupBy(u => u.Marka).OrderByDescending(u => u.Count()).Select(u => u.Key).FirstOrDefault();
            ViewBag.dgr10 = deger10;

            var deger11 = context.Uruns.Count(u => u.UrunAd == "Buzdolabı").ToString();
            ViewBag.dgr11 = deger11;

            var deger12 = context.Uruns.Count(u => u.UrunAd == "Laptop").ToString();
            ViewBag.dgr12 = deger12;

            var deger13 = context.Uruns.Where(u=>u.UrunId==(context.SatisHarekets
            .GroupBy(s => s.UrunId).OrderByDescending(s => s.Count()).Select(s => s.Key)
            .FirstOrDefault())).Select(k=>k.UrunAd).FirstOrDefault();
            ViewBag.dgr13=deger13;
            
            var deger14 = context.SatisHarekets.Sum(s => s.ToplamTutar).ToString();
            ViewBag.dgr14 = deger14;

            var deger15 = context.SatisHarekets.Count(u => u.Tarih == DateTime.Today).ToString();
            ViewBag.dgr15 = deger15;
            if (context.SatisHarekets.Count(u=>u.Tarih==DateTime.Today)!=0)
            {
                var deger16 = context.SatisHarekets.Where(s => s.Tarih == DateTime.Today).Sum(s => s.ToplamTutar).ToString();
                ViewBag.dgr16 = deger16;
            }
            else
            {
                ViewBag.dgr16 = 0;
            }
            
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in context.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }
    }
}
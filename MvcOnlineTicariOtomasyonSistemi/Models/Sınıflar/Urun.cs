using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }     //short => smallint in sql
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }     //Kritik seviye oluşturmak için 

        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyonSistemi.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturaSeriNo { get; set; }
        public DateTime Tarih { get; set; }
        
        [Column(TypeName ="Char")]
        [StringLength(5)]
        public string Saat { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string TeslimEden { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(40)]
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}

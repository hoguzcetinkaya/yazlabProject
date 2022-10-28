using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YazLab.Identity;

namespace YazLab.Models
{
    public class BasvuruModel
    {
       
            [Key]
            public int Id { get; set; }

            [DisplayName("Adınız")]
            public string Ad { get; set; }

            [DisplayName("Soyadınız")]
            public string Soyad { get; set; }
            [DisplayName("TC Kimlik Numaranız")]
            public string TC{ get; set; }

            [DisplayName("Telefon Numaranız")]
            public string TelefonNumarasi { get; set; }

            [DisplayName("Adres")]
            public string Adres { get; set; }

            [DisplayName("Staj 1")]
            public bool Staj1 { get; set; }

            [DisplayName("Staj 2")]
            public bool Staj2 { get; set; }

            [DisplayName("Staj Başlangıç Tarihiniz")]
            public DateTime StajBaslangicTarihi{ get; set; }

            [DisplayName("Staj Bitiş Tarihiniz")]
            public DateTime StajBitisTarihi { get; set; }

            [DisplayName("Çalışılacak İş Gününüz")]
            public int IsGunu { get; set; }

            [DisplayName("Genel Sağlık Sigortası")]
            public string GenelSaglikSigortasi { get; set; }

            [DisplayName("25 Yaşımı Doldurdum")]
            public string YasDoldurma { get; set; }

            [DisplayName("Firma Adı")]
            public string FirmaAd { get; set; }

            [DisplayName("Firma Faaliyet Alanı")]
            public string FirmaFaaliyetAlani { get; set; }

            [DisplayName("Firma Adresi")]
            public string FirmaAdres{ get; set; }

            [DisplayName("Firma Telefon Numarası")]
            public string FirmaTelefon { get; set; }

            public string StajDurum { get; set; }

            public string User_Id { get; set; }




        
    }
}
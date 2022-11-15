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
        public class Staj
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

            [DisplayName("Staj Türünüz")]
            public string StajTuru { get; set; }

            [DisplayName("Staj Başlangıç Tarihi")]
            public DateTime StajBaslangicTarihi{ get; set; }

            [DisplayName("Staj Bitiş Tarihi")]
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

            public bool Staj1Durum { get; set; }
            public bool Staj1OnayDurum { get; set; }

            public bool Staj2Durum { get; set; }
            public bool Staj2OnayDurum { get; set; }

            public bool Staj1Red { get; set; }
            public bool Staj2Red { get; set; }

            public int Staj1Not { get; set; }
            public int Staj2Not { get; set; }

            public string User_Id { get; set; }

        }

        public class Ime
        {
            [Key]
            public int Id { get; set; }

            [DisplayName("Adınız")]
            [Required]
            public string Ad { get; set; }

            [DisplayName("Soyadınız")]
            [Required]
            public string Soyad { get; set; }

            [DisplayName("TC Kimlik Numaranız")]
            [Required]
            public string TC { get; set; }

            [DisplayName("Telefon Numaranız")]
            [Required]
            public string TelefonNumarasi { get; set; }

            [DisplayName("Adres")]
            [Required]
            public string Adres { get; set; }

            [DisplayName("Ime dönem")]
            public string ImeDonem { get; set; }

            [DisplayName("IME Başlangıç Tarihi")]
            public DateTime ImeBaslangicTarihi { get; set; }

            [DisplayName("IME Bitiş Tarihi")]
            public DateTime ImeBitisTarihi { get; set; }

            [DisplayName("Çalışılacak İş Gününüz")]
            public int IsGunu { get; set; }

            [DisplayName("Genel Sağlık Sigortası")]
            public string GenelSaglikSigortasi { get; set; }

            [DisplayName("25 Yaşımı Doldurdum")]
            public string YasDoldurma { get; set; }

            [DisplayName("Firma Adı")]
            [Required]
            public string FirmaAd { get; set; }

            [DisplayName("Firma Faaliyet Alanı")]
            [Required]
            public string FirmaFaaliyetAlani { get; set; }

            [DisplayName("Firma Adresi")]
            [Required]
            public string FirmaAdres { get; set; }

            [DisplayName("Firma Telefon Numarası")]
            [Required]
            public string FirmaTelefon { get; set; }

            public int ImeNot { get; set; }
            public bool ImeDurum { get; set; }
            public bool ImeOnayDurum { get; set; }
            public bool ImeRed { get; set; }

            public string User_Id { get; set; }
    }
    }
}
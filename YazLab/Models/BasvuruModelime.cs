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
    public class BasvuruModelime
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

        [DisplayName("Güz")]
        public bool Guz { get; set; }

        [DisplayName("Bahar")]
        public bool Bahar { get; set; }

        [DisplayName("IME Başlangıç Tarihiniz")]
        public DateTime ImeBaslangicTarihi { get; set; }

        [DisplayName("IME Bitiş Tarihiniz")]
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

        public string imeDurum { get; set; }

        public string User_Id { get; set; }
    }
}
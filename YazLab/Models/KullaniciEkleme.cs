using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YazLab.Models
{
    public class KullaniciEkleme
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }

        [Required]
        [DisplayName("Okul Numarası")]
        public string OkulNumara { get; set; }

        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresiniz hatalıdır.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime Create_Time { get; set; }
        
        public DateTime Update_Time { get; set; }
        public string seflink { get; set; }

        public string OtoSifre { get; set; }

    }
}
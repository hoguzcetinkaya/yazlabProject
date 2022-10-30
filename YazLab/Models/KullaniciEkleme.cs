using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using YazLab.Identity;

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



        public IEnumerable<ApplicationUser> OgrenciOlanlar { get; set; }
        public IEnumerable<ApplicationUser> OgretmenOlanlar { get; set; }
        

        public IEnumerable<ApplicationUser> sorumlusuAtanan { get; set; }
        public IEnumerable<ApplicationUser> sorumlusuAtanmayan { get; set; }
        public IEnumerable<ApplicationUser> Olan { get; set; }
        public IEnumerable<ApplicationUser> Olmayan { get; set; }


        public class OgrenciAtamaOgretmen
        {
            public string[] sorumluAtanan { get; set; }
            public string[] sorumludanCikan { get; set; }
        }



    }

    
}
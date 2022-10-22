using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YazLab.Models
{
    public class Giris
    {
        [Required]
        [DisplayName("Eposta")]
        [EmailAddress(ErrorMessage = "Eposta adresiniz hatalıdır.")]
        public string Email { get; set; }

        
        [Required]
        [DisplayName("Parola")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }


    }
}
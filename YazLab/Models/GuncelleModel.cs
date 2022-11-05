using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YazLab.Models
{
    public class GuncelleModel
    {
        public class SifreGuncelle
        {
            [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Şifrenizde en az 8 karakterden oluşmalı ve en az bir büyük harf,bir küçük harf ve bir rakam bulunmalıdır")]
            [Required]
            [DisplayName("Şifre")]
            public string Password { get; set; }

            [Required]
            [DisplayName("Şifre Tekrar")]
            [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor")]
            public string RePassword { get; set; }


        }
    }
}
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
        [Required(ErrorMessage ="Kullanıcı adınızı boş bırakmayınız...")]
        [DisplayName("Kullanıcı adınız")]
        public string UserName { get; set; }

        
        [Required]
        [DisplayName("Parolanız")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

        public DateTime baslangic { get; set; }
        public DateTime bitis { get; set; }

    }
}
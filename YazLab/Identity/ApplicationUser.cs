using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YazLab.Models;

namespace YazLab.Identity
{
    public class ApplicationUser:IdentityUser
    {
       
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OkulNumara { get; set; }
        public string Sorumlu { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }
        public string OtoSifre { get; set; }
        public string Seflink { get; set; }

       
        public ICollection<BasvuruModel.Staj> Stajs { get; set; }
        public ICollection<BasvuruModel.Ime> Imes { get; set; }

    }
}
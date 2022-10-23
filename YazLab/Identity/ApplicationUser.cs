using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


    }
}
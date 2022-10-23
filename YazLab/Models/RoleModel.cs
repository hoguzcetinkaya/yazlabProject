using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YazLab.Identity;

namespace YazLab.Models
{
    public class RoleModel
    {
        public class RoledekiKullanicilar
        {
            public IdentityRole rol { get; set; }
            public IEnumerable<ApplicationUser> roluOlanlar { get; set; }//üyeler
            public IEnumerable<ApplicationUser> roluOlmayanlar { get; set; }
        }

        public class RoleGuncelleme
        {
            [Required]
            public string roleName { get; set; }
            public string roleId { get; set; }
            public string[] idsToAdd { get; set; }
            public string[] idsToDelete { get; set; }
        }
    }
}
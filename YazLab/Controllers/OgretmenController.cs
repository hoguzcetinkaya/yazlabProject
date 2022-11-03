using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using System.Collections;

namespace YazLab.Controllers
{
    public class OgretmenController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public OgretmenController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Staj1Notlandirma()
        {
            
            DataContext db = new DataContext();
            var ogretmenBilgi = userManager.FindByName(User.Identity.Name);
            var ogrenciBilgi = userManager.Users.Where(x => x.Sorumlu == ogretmenBilgi.Id).ToList();
            if(ogrenciBilgi.Count()!=0)
            {
                var list = new List<Models.BasvuruModel.Staj>();
                int sayac = 0;
                foreach (var item in ogrenciBilgi)
                {
                    sayac++;
                    var ogretmeneAitOgrenciListesi = db.Stajs.Single(x => x.StajTuru == "Staj1" && x.User_Id == item.Id && x.Staj1Durum==true && x.Staj1OnayDurum==true && x.Staj2Durum==false && x.Staj2OnayDurum==false);
                   
                    list.Add(ogretmeneAitOgrenciListesi);
                    if(sayac==ogrenciBilgi.Count())
                    {
                        return View(list);
                        
                    }
                }
                
            }
            return View();
            
        }
    }
}
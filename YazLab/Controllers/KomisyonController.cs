using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using YazLab.Models;

namespace YazLab.Controllers
{
    public class KomisyonController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public KomisyonController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }
        // GET: Komisyon
        public ActionResult Index()
        {
            var user = userManager.FindByName(User.Identity.Name);
            if (user != null)
            {
                if (userManager.IsInRole(user.Id, "ogretmen") && userManager.IsInRole(user.Id,"komisyon"))
                {
                    return View();
                }
            }
            return RedirectToAction("Index","Ogretmen");        
        }

        [HttpGet]
        public ActionResult Staj1OnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Stajs.ToList().Where(x => x.Staj1OnayDurum == false && x.Staj1Durum==true));
        }

        [HttpPost]
        public ActionResult Staj1OnayBekleyenler(int id)
        {
            
            DataContext db = new DataContext();
            var basvuruStaj1 = new BasvuruModel.Staj();
            var staj1BasvuruOnaylanacakOgrenci = db.Stajs.Where(x=>x.Id==id).ToList();
            var staj1BasvuruOgrenci = staj1BasvuruOnaylanacakOgrenci.LastOrDefault();
            
            if (staj1BasvuruOnaylanacakOgrenci != null && staj1BasvuruOgrenci.Staj1Durum==true && staj1BasvuruOgrenci.Staj1OnayDurum==false && staj1BasvuruOgrenci.Staj1Red==false)
            {
                staj1BasvuruOgrenci.Staj1OnayDurum = true;
                db.SaveChanges();
            }
            return RedirectToAction("Staj1OnayBekleyenler");
            
        }


        [HttpGet]
        public ActionResult Staj1Red(int id)
        {
            DataContext db = new DataContext();
            var basvuruStaj1 = new BasvuruModel.Staj();
            var staj1BasvuruRedOgrenci = db.Stajs.Where(x=>x.Id==id && x.StajTuru=="Staj1").ToList();
            var staj1BasvuruOgrenci = staj1BasvuruRedOgrenci.LastOrDefault();
            
            if (staj1BasvuruRedOgrenci != null && staj1BasvuruOgrenci.Staj1Durum==true && staj1BasvuruOgrenci.Staj1OnayDurum==false && staj1BasvuruOgrenci.Staj1Red==false)
            {
                staj1BasvuruOgrenci.Staj1OnayDurum = true;
                staj1BasvuruOgrenci.Staj1Red = true;
                db.SaveChanges();
            }
            return RedirectToAction("Staj1OnayBekleyenler");
        }

        [HttpGet]
        public ActionResult Staj2Red(int id)
        {
            DataContext db = new DataContext();
            var basvuruStaj1 = new BasvuruModel.Staj();
            var staj1BasvuruRedOgrenci = db.Stajs.Where(x => x.Id == id && x.StajTuru=="Staj2").ToList();
            var staj1BasvuruOgrenci = staj1BasvuruRedOgrenci.LastOrDefault();

            if (staj1BasvuruRedOgrenci != null && staj1BasvuruOgrenci.Staj1Durum == true && staj1BasvuruOgrenci.Staj1OnayDurum == true && staj1BasvuruOgrenci.Staj2Durum==true && staj1BasvuruOgrenci.Staj2OnayDurum==false && staj1BasvuruOgrenci.Staj1Red == false && staj1BasvuruOgrenci.Staj2Red==false)
            {
                staj1BasvuruOgrenci.Staj1Durum = true;
                staj1BasvuruOgrenci.Staj1OnayDurum = true;
                staj1BasvuruOgrenci.Staj2Durum = true;
                staj1BasvuruOgrenci.Staj2OnayDurum = true;
                staj1BasvuruOgrenci.Staj1Red = false;
                staj1BasvuruOgrenci.Staj2Red = true;
                db.SaveChanges();
            }
            return RedirectToAction("Staj2OnayBekleyenler");
        }



        [HttpGet]
        public ActionResult Staj2OnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Stajs.ToList().Where(x => x.Staj2OnayDurum == false && x.Staj2Durum == true && x.Staj1Durum==true && x.Staj1OnayDurum==true));
        }

        [HttpPost]
        public ActionResult Staj2OnayBekleyenler(int id)
        {
            DataContext db = new DataContext();
            var basvuruStaj2 = new BasvuruModel.Staj();
            var staj2BasvuruOnaylanacakOgrenci = db.Stajs.Single(x => x.Id == id);

            if (staj2BasvuruOnaylanacakOgrenci != null && staj2BasvuruOnaylanacakOgrenci.Staj2Durum == true && staj2BasvuruOnaylanacakOgrenci.Staj2OnayDurum == false)
            {
                staj2BasvuruOnaylanacakOgrenci.Staj2OnayDurum = true;
                db.SaveChanges();


            }

            return RedirectToAction("Staj2OnayBekleyenler");

        }


        [HttpGet]
        public ActionResult ImeOnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Imes.ToList().Where(x => x.ImeOnayDurum == false && x.ImeDurum == true));
        }

        [HttpPost]
        public ActionResult ImeOnayBekleyenler(int id)
        {
            DataContext db = new DataContext();
            var ımeBasvuru = new BasvuruModel.Staj();
            var ımeBasvuruOnaylanacakOgrenci = db.Imes.Single(x => x.Id == id);

            if (ımeBasvuruOnaylanacakOgrenci != null && ımeBasvuruOnaylanacakOgrenci.ImeDurum == true && ımeBasvuruOnaylanacakOgrenci.ImeOnayDurum == false)
            {
                ımeBasvuruOnaylanacakOgrenci.ImeOnayDurum = true;
                db.SaveChanges();
            }

            return RedirectToAction("ImeOnayBekleyenler");

        }

        [HttpGet]
        public ActionResult IMERed(int id)
        {
            DataContext db = new DataContext();
            var basvuruIME = new BasvuruModel.Ime();
            var IMERedOgrenci = db.Imes.Where(x => x.Id == id).ToList();
            var IMEBasvuruOgrenci = IMERedOgrenci.LastOrDefault();

            if (IMERedOgrenci != null && IMEBasvuruOgrenci.ImeDurum == true && IMEBasvuruOgrenci.ImeOnayDurum==false && IMEBasvuruOgrenci.ImeRed==false)
            {
                IMEBasvuruOgrenci.ImeDurum = true;
                IMEBasvuruOgrenci.ImeOnayDurum = true;
                IMEBasvuruOgrenci.ImeRed = true;
                db.SaveChanges();
            }
            return RedirectToAction("ImeOnayBekleyenler");
        }
    }
}
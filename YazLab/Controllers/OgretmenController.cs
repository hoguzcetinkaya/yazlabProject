using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using System.Collections;
using YazLab.Models;

namespace YazLab.Controllers
{
    [Authorize(Roles = "ogretmen")]
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
            if (ogrenciBilgi.Count() != 0)
            {
                var list = new List<Models.BasvuruModel.Staj>();
                int sayac = 0;
                foreach (var item in ogrenciBilgi)
                {
                    sayac++;

                    var ogrenciStaj1Bilgi = db.Stajs.Where(x => x.User_Id == item.Id).ToList();
                    foreach (var ogrStajBilgi in ogrenciStaj1Bilgi)
                    {
                        if (ogrStajBilgi.StajTuru == "Staj1")
                        {
                            if (ogrStajBilgi.Staj2Not == 0 && ogrStajBilgi.Staj1Durum == true && ogrStajBilgi.Staj1OnayDurum == true)
                            {
                                list.Add(ogrStajBilgi);

                            }
                        }
                    }

                }
                return View(list);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Staj1Notlandirma(BasvuruModel.Staj model, string not)
        {
            if (ModelState.IsValid)
            {
                DataContext db = new DataContext();
                
                if (not!="")
                {
                    int intNot = Int32.Parse(not);
                    if (intNot >= 1 && intNot <= 100)
                    {
                        var kullaniciStajBilgi = db.Stajs.Single(x => x.Id == model.Id);
                        kullaniciStajBilgi.Staj1Not = intNot;
                        db.SaveChanges();

                        TempData["basarili"] = "Not verme işlemi başarılı";
                        return RedirectToAction("Staj1Notlandirma");
                    }
                    else
                    {
                        TempData["hata"] = "Not aralığı 1 ile 100 arasında olmalıdır";
                        return RedirectToAction("Staj1Notlandirma");
                    }
                    
                    
                }
                TempData["hata"] = "Notu boş bırakmayınız";
                return RedirectToAction("Staj1Notlandirma");

            }
            return View();
        }

        [HttpGet]
        public ActionResult Staj2Notlandirma()
        {

            DataContext db = new DataContext();
            var ogretmenBilgi = userManager.FindByName(User.Identity.Name);
            var ogrenciBilgi = userManager.Users.Where(x => x.Sorumlu == ogretmenBilgi.Id).ToList();
            if (ogrenciBilgi.Count() != 0)
            {
                var list = new List<Models.BasvuruModel.Staj>();
                int sayac = 0;
                foreach (var item in ogrenciBilgi)
                {
                    sayac++;

                    var ogrenciStaj2Bilgi = db.Stajs.Where(x=>x.User_Id==item.Id).ToList();
                    foreach (var ogrStajBilgi in ogrenciStaj2Bilgi)
                    {
                        if (ogrStajBilgi.StajTuru == "Staj2")
                        {
                            if (ogrStajBilgi.Staj1Not != 0 && ogrStajBilgi.Staj2Durum == true && ogrStajBilgi.Staj2OnayDurum == true)
                            {
                                list.Add(ogrStajBilgi);
                                
                            }
                        }
                    }
                    
                }
                return View(list);
            }
            return View();

        }

        [HttpPost]
        public ActionResult Staj2Notlandirma(BasvuruModel.Staj model, string not)
        {
            if (ModelState.IsValid)
            {
                DataContext db = new DataContext();

                if (not != "")
                {
                    int intNot = Int32.Parse(not);
                    if (intNot >= 1 && intNot <= 100)
                    {
                        var kullaniciStajBilgi = db.Stajs.Single(x => x.Id == model.Id);
                        kullaniciStajBilgi.Staj2Not = intNot;
                        db.SaveChanges();

                        TempData["basarili"] = "Not verme işlemi başarılı";
                        return RedirectToAction("Staj2Notlandirma");
                    }
                    else
                    {
                        TempData["hata"] = "Not aralığı 1 ile 100 arasında olmalıdır";
                        return RedirectToAction("Staj2Notlandirma");
                    }


                }
                TempData["hata"] = "Notu boş bırakmayınız";
                return RedirectToAction("Staj2Notlandirma");

            }
            return View();
        }




        [HttpGet]
        public ActionResult ImeNotlandirma()
        {

            DataContext db = new DataContext();
            var ogretmenBilgi = userManager.FindByName(User.Identity.Name);
            var ogrenciBilgi = userManager.Users.Where(x => x.Sorumlu == ogretmenBilgi.Id).ToList();
            if (ogrenciBilgi.Count() != 0)
            {
                var list = new List<Models.BasvuruModel.Ime>();
                int sayac = 0;
                foreach (var item in ogrenciBilgi)
                {
                    sayac++;

                    var ogrenciImeBilgi = db.Imes.Where(x => x.User_Id == item.Id).ToList();
                    foreach (var ogrStajBilgi in ogrenciImeBilgi)
                    {
                        
                            if ( ogrStajBilgi.ImeDurum == true && ogrStajBilgi.ImeOnayDurum == true)
                            {
                                list.Add(ogrStajBilgi);

                            }
                        
                    }

                }
                return View(list);
            }
            return View();

        }

        [HttpPost]
        public ActionResult ImeNotlandirma(BasvuruModel.Ime model, string not)
        {
            
                DataContext db = new DataContext();

                if (not != "")
                {
                    int intNot = Int32.Parse(not);
                    if (intNot >= 1 && intNot <= 100)
                    {
                        var kullaniciStajBilgi = db.Imes.Single(x => x.Id == model.Id);
                        kullaniciStajBilgi.ImeNot = intNot;
                        db.SaveChanges();

                        TempData["basarili"] = "Not verme işlemi başarılı";
                        return RedirectToAction("ImeNotlandirma");
                    }
                    else
                    {
                        TempData["hata"] = "Not aralığı 1 ile 100 arasında olmalıdır";
                        return RedirectToAction("ImeNotlandirma");
                    }


                }
                TempData["hata"] = "Notu boş bırakmayınız";
                return RedirectToAction("ImeNotlandirma");

            
            
        }


        [HttpGet]
        public ActionResult SorumluOldugumOgrenciler()
        {

            var ogretmen = userManager.FindByName(User.Identity.Name);

            
            return View(userManager.Users.Where(x => x.Sorumlu == ogretmen.Id).ToList());
        }
    }
}
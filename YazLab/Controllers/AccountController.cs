using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using YazLab.Models;
using Microsoft.Owin.Security;

namespace YazLab.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }

        [HttpGet]
        public ActionResult GirisSec()
        {
            return View();
        }
        public ActionResult OgrenciGiris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgrenciGiris(Giris model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    if (userManager.IsInRole(user.Id, "ogrenci"))
                    {
                        var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                        var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
                        var authProperties = new AuthenticationProperties();
                        authProperties.IsPersistent = model.RememberMe;//hatırlamak için
                        authManager.SignOut();
                        authManager.SignIn(authProperties, identityclaims);

                        if (user.OtoSifre == null)
                        {
                            return RedirectToAction("index", "Ogrenci");
                        }
                        else
                        {
                            return RedirectToAction("SifreGuncelle", "Account");

                        }



                    }
                    else
                    {
                        ModelState.AddModelError("", "Giriş bilgilerinizi kontrol ediniz...");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                }


            }
            return View(model);
        }


        [HttpGet]
        public ActionResult OgretmenGiris()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OgretmenGiris(Giris model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    if (userManager.IsInRole(user.Id, "ogretmen"))
                    {

                        var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                        var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
                        var authProperties = new AuthenticationProperties();
                        authProperties.IsPersistent = model.RememberMe;//hatırlamak için
                        authManager.SignOut();
                        authManager.SignIn(authProperties, identityclaims);

                        ViewBag.userBilgi = user;
                        if (user.OtoSifre == null)
                        {
                            return RedirectToAction("index", "Ogretmen");
                        }
                        else
                        {
                            return RedirectToAction("SifreGuncelle", "Account");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Giriş bilgilerinizi kontrol ediniz...");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                }


            }
            return View(model);

            //if (ModelState.IsValid)
            //{
            //    var user = userManager.Find(model.UserName, model.Password);
            //    if (user != null)
            //    {
            //        if (userManager.IsInRole(user.Id, "ogretmen") && userManager.IsInRole(user.Id,"komisyon"))
            //        {

            //            var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
            //            var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
            //            var authProperties = new AuthenticationProperties();
            //            authProperties.IsPersistent = model.RememberMe;//hatırlamak için
            //            authManager.SignOut();
            //            authManager.SignIn(authProperties, identityclaims);

            //            ViewBag.userBilgi = user;
            //            if (user.OtoSifre == null)
            //            {

            //                return RedirectToAction("index", "Ogretmen");
            //            }
            //            else
            //            {
            //                return RedirectToAction("SifreGuncelle", "Account");

            //            }
            //        }
            //        else
            //        {
            //            ModelState.AddModelError("", "Giriş bilgilerinizi kontrol ediniz...");
            //        }
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Kullanıcı bulunamadı");
            //    }


            //}
            //return View(model);
        }
        [HttpGet]
        public ActionResult YoneticiGiris()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YoneticiGiris(Giris model)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    if (userManager.IsInRole(user.Id, "admin"))
                    {
                        var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                        var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
                        var authProperties = new AuthenticationProperties();
                        authProperties.IsPersistent = model.RememberMe;//hatırlamak için
                        authManager.SignOut();
                        authManager.SignIn(authProperties, identityclaims);


                        if (user.OtoSifre == null)
                        {
                            return RedirectToAction("index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("SifreGuncelle", "Account");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Giriş bilgilerinizi kontrol ediniz...");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                }


            }
            return View(model);
        }


        public ActionResult Cikis()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("GirisSec", "Account");
        }


        public ActionResult SifreGuncelle()
        {
            string id = User.Identity.GetUserId();
            ApplicationUser user = userManager.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View();


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SifreGuncelle(GuncelleModel.SifreGuncelle model)
        {
            
            

                string id = User.Identity.GetUserId();
                var user = userManager.Users.FirstOrDefault(x => x.Id == id);

                //user.PasswordHash = model.Password;
                user.PasswordHash = userManager.PasswordHasher.HashPassword(model.Password);

                user.OtoSifre = null;
                userManager.Update(user);
                var authManager = HttpContext.GetOwinContext().Authentication;
                authManager.SignOut();

                return RedirectToAction("GirisSec", "Account");
            
           





        }


    }
}
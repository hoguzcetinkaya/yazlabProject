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
                    if(userManager.IsInRole(user.Id,"ogrenci"))
                    {
                        var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                        var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
                        var authProperties = new AuthenticationProperties();
                        authProperties.IsPersistent = model.RememberMe;//hatırlamak için
                        authManager.SignOut();
                        authManager.SignIn(authProperties, identityclaims);


                        return RedirectToAction("index", "Ogrenci");
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
                        return RedirectToAction("index", "Komisyon");
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


                        return RedirectToAction("index", "Admin");
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





    }
}
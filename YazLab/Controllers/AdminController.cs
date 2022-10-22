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
using System.Net.NetworkInformation;

namespace YazLab.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        public string seflink(string x)
        {
            x = x.Trim();
            x = x.Replace("ã¢", "a");
            x = x.Replace("ã‚", "a");
            x = x.Replace("ãª", "e");
            x = x.Replace("ãš", "e");
            x = x.Replace("ã§", "c");
            x = x.Replace("ã‡", "c");
            x = x.Replace("äÿ", "g");
            x = x.Replace("ä", "g");
            x = x.Replace("ä°", "i");
            x = x.Replace("ä±", "i");
            x = x.Replace("ã¶", "o");
            x = x.Replace("ã–", "o");
            x = x.Replace("åÿ", "s");
            x = x.Replace("å", "s");
            x = x.Replace("ã¼", "u");
            x = x.Replace("ãœ", "u");
            x = x.Replace("â", "a");
            x = x.Replace("Â", "a");
            x = x.Replace("ê", "e");
            x = x.Replace("Ê", "e");
            x = x.Replace("ç", "c");
            x = x.Replace("Ç", "c");
            x = x.Replace("ğ", "g");
            x = x.Replace("Ğ", "g");
            x = x.Replace("İ", "i");
            x = x.Replace("I", "i");
            x = x.Replace("ı", "i");
            x = x.Replace("î", "i");
            x = x.Replace("Î", "i");
            x = x.Replace("î", "i");
            x = x.Replace("ö", "o");
            x = x.Replace("Ö", "o");
            x = x.Replace("ş", "s");
            x = x.Replace("Ş", "s");
            x = x.Replace("ü", "u");
            x = x.Replace("Ü", "u");
            x = x.Replace(" ", "");
            x = x.ToLower();
            return x;
        }

        public ActionResult KullaniciEkleme()
        {
            return View();
        }
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciEkleme(KullaniciEkleme model)
        {



            if (ModelState.IsValid)
            {

                string kullaniciAdi = model.Name + " " + model.Surname;

                string seflinkKullaniciAdi = seflink(kullaniciAdi);
                //kayt işlemleri
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName= seflinkKullaniciAdi;
                user.OkulNumara = model.OkulNumara;
                user.Create_Time = DateTime.Now;
                user.Update_Time = DateTime.Now;
                user.PhoneNumber = model.PhoneNumber;
                var a = CreateRandomPassword(8);
                user.OtoSifre = a;
                IdentityResult result = UserManager.Create(user,a );


                if (result.Succeeded)
                {

                    //kullanıcı oluşunca role atıyoruz!!!

                    if (RoleManager.RoleExists("ogrenci"))
                    {
                        UserManager.AddToRole(user.Id, "ogrenci");
                    }
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }

            }

            return View(model);
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Giris(Giris model)
        {
            if (ModelState.IsValid)
            {
                //Login İşlemleri
                var user = UserManager.Find(model.Email, model.Password);
                if (user != null)
                {
                    //kullanıcı varsa sistem dahil et
                    //Aplication cookie oluşturup sisteme bırak

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    return RedirectToAction("KullaniciEkleme", "Admin");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Giris hatası");
                }

            }
            return View(model);
        }
        public ActionResult Cikis()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            
            return RedirectToAction("Index","Admin");
        }


    }
}
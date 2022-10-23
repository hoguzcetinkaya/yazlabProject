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
using System.Web.Helpers;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace YazLab.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AdminController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
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

        public ActionResult Index()
        {

            return View(userManager.Users);
        }

        [HttpGet]
        public ActionResult KullaniciEkleme()
        {
            return View();

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
                user.UserName = model.OkulNumara;
                user.OkulNumara = model.OkulNumara;
                user.Create_Time = DateTime.Now;
                user.Update_Time = DateTime.Now;
                user.PhoneNumber = model.PhoneNumber;
                user.Seflink = seflinkKullaniciAdi;
                var a = CreateRandomPassword(8);
                user.OtoSifre = a;
                IdentityResult result = userManager.Create(user, a);
                if (result.Succeeded)
                {

                    //kullanıcı oluşunca role atıyoruz!!!

                    userManager.AddToRole(user.Id, "ogrenci");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı oluşturma hatası");
                }

            }

            return View(model);
        }

        [HttpGet]
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
                TimeSpan gunFarki = model.bitis - model.baslangic;
                double gun = gunFarki.TotalDays;


                //Login İşlemleri
                var user = userManager.Find(model.UserName, model.Password);
                //var user = userManager.Find(model.Email,model.Password);
                if (user != null)
                {


                    var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                    var identityclaims = userManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;//hatırlamak için
                    authManager.SignOut();
                    authManager.SignIn(authProperties, identityclaims);
                    return RedirectToAction("index", "Admin");

                    //kullanıcı varsa sistem dahil et
                    //Aplication cookie oluşturup sisteme bırak


                }
                else
                {
                    ModelState.AddModelError("", "Giris hatası");
                }

            }
            return View(model);
        }


        public ActionResult Cikis()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Admin");
        }






        //Rol işlemleri
        public ActionResult RoleIndex()
        {
            return View(roleManager.Roles);
        }

        [HttpGet]
        public ActionResult RoleOlustur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleOlustur(string rolAd)
        {
            if (ModelState.IsValid)
            {
                var result = roleManager.Create(new IdentityRole(rolAd));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleIndex");
                }
                else
                {
                    ModelState.AddModelError("", "Rol oluşturulamadı...!!");
                }
            }
            return View(rolAd);
        }


        [HttpPost]
        public ActionResult RolKaldir(string id)
        {
            var role = roleManager.FindById(id);
            if (role != null)
            {
                var result = roleManager.Delete(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleIndex");
                }
                else
                {
                    ModelState.AddModelError("", "Rol silme işlemi başarısız");
                }
            }
            else
            {
                ModelState.AddModelError("", "Rol bulunamadı");

            }
            return View();
        }

        [HttpGet]
        public ActionResult RolGuncelle(string id)
        {
            var rolBilgiler = roleManager.FindById(id);//role bilgilerini çektik
            var roluOlanKullanicilar = new List<ApplicationUser>();//kayıtlı kullanıcılara ulaştık
            var roluOlmayanKullanicilar = new List<ApplicationUser>();

            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, rolBilgiler.Name) ? roluOlanKullanicilar : roluOlmayanKullanicilar; //kullanıcının rolu varsa roluOlanKullanıcılara yoksa olmayana ekle
                list.Add(user);
            }

            return View(new RoleModel.RoledekiKullanicilar()
            {
                rol = rolBilgiler,
                roluOlanlar = roluOlanKullanicilar,
                roluOlmayanlar = roluOlmayanKullanicilar
            });
        }

        [HttpPost]
        public ActionResult RolGuncelle(RoleModel.RoleGuncelleme model)
        {
            if (ModelState.IsValid)
            {
                //checkbox ile seçili kullanıcıları role ekleme işlemli
                foreach (var userId in model.idsToAdd ?? new string[] { })
                {
                    IdentityResult result = userManager.AddToRole(userId, model.roleName);
                    if (!result.Succeeded)//hata yoksa role ekle
                    {
                        return View("Error", result.Errors);
                    }
                }
                foreach (var userId in model.idsToDelete ?? new string[] { })
                {
                    var result = userManager.RemoveFromRole(userId, model.roleName);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Rol yetkilendirmesi başarısız...!");

                    }
                   
                }
                return RedirectToAction("RolGuncelle");
            }
            return View("Error", new string[] { "Böyle bir rol bulunmamakta" });

        }
    }
}
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
using System.Runtime.InteropServices.WindowsRuntime;

namespace YazLab.Controllers
{
    //[Authorize(Roles = "admin")]
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






            //var user = userManager.FindByName(User.Identity.Name);
            //if (user != null)
            //{
            //    ViewBag.v = user.Email;
            //}


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
                string subject = "Staj sistemi giriş bilgileriniz";
                string body = "Şifreniz: " + a +
                    " /               kullanıcı adınız:" + model.OkulNumara;
                WebMail.Send(model.Email, subject, body, null, null, null, true, null, null, null, null, null, null);
                ViewBag.Mesaj = "Şifre gönderimi başarılı";
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




        public ActionResult OgrenciListesi()
        {
            var rolId = roleManager.FindByName("ogrenci");

            var OgrenciOlanlarC = new List<ApplicationUser>();//kayıtlı kullanıcılara ulaştık
            var OgrenciOlmayanlar = new List<ApplicationUser>();



            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, "ogrenci") ? OgrenciOlanlarC : OgrenciOlmayanlar;
                list.Add(user);


            }

            return View(new KullaniciEkleme()
            {
                OgrenciOlanlar = OgrenciOlanlarC,
            });
        }
        public ActionResult OgretmenListesi()
        {
            var rolId = roleManager.FindByName("ogretmen");

            var OgretmenOlanlarC = new List<ApplicationUser>();//kayıtlı kullanıcılara ulaştık
            var OgretmenOlmayanlarC = new List<ApplicationUser>();



            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, "ogretmen") ? OgretmenOlanlarC : OgretmenOlmayanlarC;
                list.Add(user);


            }

            return View(new KullaniciEkleme()
            {
                OgretmenOlanlar = OgretmenOlanlarC,
            });
        }

        [HttpGet]
        public ActionResult OgrenciAtamaOgretmen(string id)
        {
            var sorumlusuAtananC = new List<ApplicationUser>();//kayıtlı kullanıcılara ulaştık
            var sorumlusuAtanmayanC = new List<ApplicationUser>();
            var OlanC = new List<ApplicationUser>();
            var OlmayanC = new List<ApplicationUser>();
            ViewBag.OgretmenId = id;

            foreach (var user in userManager.Users.ToList())
            {
                if (userManager.IsInRole(user.Id, "ogrenci"))
                {
                    if(user.Sorumlu==id)
                    {
                        var list = userManager.IsInRole(user.Id, "ogrenci") ? sorumlusuAtananC : sorumlusuAtanmayanC;
                        list.Add(user);
                    }
                    else if(user.Sorumlu==null)
                    {
                        var list = userManager.IsInRole(user.Id, "ogrenci") ? sorumlusuAtanmayanC : sorumlusuAtananC;
                        list.Add(user);
                    }
                    
                }
                if (userManager.IsInRole(user.Id, "ogretmen"))
                {
                    var list = userManager.IsInRole(user.Id, "ogretmen") ? OlanC : OlmayanC;
                    list.Add(user);
                }       

            }

            return View(new KullaniciEkleme()
            {
                sorumlusuAtanan=sorumlusuAtananC,
                sorumlusuAtanmayan=sorumlusuAtanmayanC,
                 Olan=OlanC,
                  Olmayan=OlmayanC
            });
        }

        [HttpPost]
        public ActionResult OgrenciAtamaOgretmen(KullaniciEkleme.OgrenciAtamaOgretmen model,string ogretmenid)
        {
            if (ModelState.IsValid)
            {
                //checkbox ile seçili kullanıcıları role ekleme işlemli
                foreach (var userId in model.sorumluAtanan ?? new string[] { })
                {
                    ApplicationUser user = userManager.FindById(userId);

                    var sorumlu = userManager.FindById(ogretmenid);
                    user.Sorumlu = sorumlu.Id;
                    userManager.Update(user);
                }
                foreach (var userId in model.sorumludanCikan ?? new string[] { })
                {
                    var user = userManager.FindById(userId);
                    user.Sorumlu = null;
                    userManager.Update(user);

                }
                return RedirectToAction("OgrenciAtamaOgretmen");
            }
            return View("Error", new string[] { "Böyle bir rol bulunmamakta" });
            
        }

        [HttpGet]
        public ActionResult OgretmenAtamaKomisyon(string id)
        {
            var sorumlusuAtananC = new List<ApplicationUser>();//kayıtlı kullanıcılara ulaştık
            var sorumlusuAtanmayanC = new List<ApplicationUser>();
            var OlanC = new List<ApplicationUser>();
            var OlmayanC = new List<ApplicationUser>();
            ViewBag.OgretmenId = id;

            foreach (var user in userManager.Users.ToList())
            {
                if (userManager.IsInRole(user.Id, "ogrenci"))
                {
                    if (user.Sorumlu == id)
                    {
                        var list = userManager.IsInRole(user.Id, "ogrenci") ? sorumlusuAtananC : sorumlusuAtanmayanC;
                        list.Add(user);
                    }
                    else if (user.Sorumlu == null)
                    {
                        var list = userManager.IsInRole(user.Id, "ogrenci") ? sorumlusuAtanmayanC : sorumlusuAtananC;
                        list.Add(user);
                    }

                }
                if (userManager.IsInRole(user.Id, "ogretmen"))
                {
                    var list = userManager.IsInRole(user.Id, "ogretmen") ? OlanC : OlmayanC;
                    list.Add(user);
                }

            }

            return View(new KullaniciEkleme()
            {
                sorumlusuAtanan = sorumlusuAtananC,
                sorumlusuAtanmayan = sorumlusuAtanmayanC,
                Olan = OlanC,
                Olmayan = OlmayanC
            });
        }

    }

}
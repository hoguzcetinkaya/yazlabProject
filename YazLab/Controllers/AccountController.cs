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
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
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



                //Login İşlemleri
                var user = UserManager.Find(model.UserName, model.Password);
                //var user = userManager.Find(model.Email,model.Password);
                if (user != null)
                {


                    var authManager = HttpContext.GetOwinContext().Authentication;// kullanıcı girdi çıktılarını yönetmek için
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie"); // kullanıcı için cookie oluşturmak için
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



    }
}
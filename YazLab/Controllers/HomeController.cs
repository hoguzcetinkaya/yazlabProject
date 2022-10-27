using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using YazLab.Models;
using YazLab.Pdf;

namespace YazLab.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public HomeController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }
        // GET: Home
        //public ActionResult Index(KullaniciEkleme model)
        //{
        //    PdfAyarlari pdfAyarlari = new PdfAyarlari();//employeeReport
        //    byte[] abytes = pdfAyarlari.ReportPdf(GetKullanicilar());
        //    return File(abytes,"application/Pdf");
        //}


        //var user = userManager.FindByName(User.Identity.Name);
        public ApplicationUser GetKullanicilar()
        {
            ApplicationUser kliste = new ApplicationUser();
            ApplicationUser kullanici = new ApplicationUser();

            var kullaniciBilgi = userManager.FindByName(User.Identity.Name);

            kullanici.Name = kullaniciBilgi.Name;
            kullanici.Surname = kullaniciBilgi.Surname;
            kullanici.PhoneNumber = kullaniciBilgi.PhoneNumber;

            return kliste;
        }


        public ActionResult Giris()
        {
            return View();
        }
    }
}
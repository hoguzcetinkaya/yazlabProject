using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using YazLab.Models;
using YazLab.Pdf;

namespace YazLab.Controllers
{
    public class OgrenciController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        public OgrenciController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityContext()));
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityContext()));
        }
        

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Staj1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Staj1(BasvuruModel.Staj1 model)
        {
            if(ModelState.IsValid)
            {
                TimeSpan gunFarki = model.StajBitisTarihi - model.StajBaslangicTarihi;
                double gun = gunFarki.TotalDays;
                if( model.IsGunu==30)
                {
                    DataContext db = new DataContext();
                    ApplicationUser kullanici = userManager.FindByName(User.Identity.Name);
                    
                    var basvuru = new BasvuruModel.Staj1();
                    basvuru.Ad = model.Ad;
                    basvuru.Soyad = model.Soyad;
                    basvuru.TC = model.TC;
                    basvuru.TelefonNumarasi = model.TelefonNumarasi;
                    basvuru.Adres = model.Adres;
                    basvuru.StajTuru = model.StajTuru;
                    basvuru.StajBaslangicTarihi = model.StajBaslangicTarihi;
                    basvuru.StajBitisTarihi = model.StajBitisTarihi;
                    basvuru.IsGunu = model.IsGunu;
                    basvuru.GenelSaglikSigortasi = model.GenelSaglikSigortasi;
                    basvuru.YasDoldurma = model.YasDoldurma;
                    basvuru.FirmaAd = model.FirmaAd;
                    basvuru.FirmaFaaliyetAlani = model.FirmaFaaliyetAlani;
                    basvuru.FirmaAdres = model.FirmaAdres;
                    basvuru.FirmaTelefon = model.FirmaTelefon;
                    basvuru.User_Id= kullanici.Id; //staj1 modelinde oluşturduğum user_ıd foreign key
                    db.Stajs.Add(basvuru);
                    db.SaveChanges();
                    TempData["Success"] = "Başvuru Başarılı";
                    return RedirectToAction("Index", "Ogrenci");
                }
                else
                {
                    ModelState.AddModelError("", "Başvuru tamamlanamadı");
                }
                
                
            }
            return View(model);
        }

        public ActionResult PdfIndex(BasvuruModel.Staj1 model)
        {
            PdfAyarlari pdfAyarlari = new PdfAyarlari();//employeeReport
            byte[] abytes = pdfAyarlari.ReportPdf(GetKullanicilar());
            return File(abytes, "application/Pdf");

        }
        public List<BasvuruModel.Staj1> GetKullanicilar()
        {
            DataContext db = new DataContext();
            List<BasvuruModel.Staj1> stajListe = new List<BasvuruModel.Staj1>();
            BasvuruModel.Staj1 stajBilgi = new BasvuruModel.Staj1();

            var kullaniciBilgi = userManager.FindByName(User.Identity.Name);
            var kullanici = db.Stajs.FirstOrDefault(x=>x.User_Id==kullaniciBilgi.Id);
            
            for (int i = 0; i < 1; i++)
            {
                stajBilgi.Ad = kullanici.Ad;
                stajBilgi.Soyad = kullanici.Soyad;
                stajBilgi.TC = kullanici.TC;
                stajBilgi.TelefonNumarasi = kullanici.TelefonNumarasi;
                stajBilgi.Adres = kullanici.Adres;
                stajBilgi.StajTuru = kullanici.StajTuru;
                stajBilgi.StajBaslangicTarihi = kullanici.StajBaslangicTarihi;
                stajBilgi.StajBitisTarihi = kullanici.StajBitisTarihi;
                stajBilgi.IsGunu = kullanici.IsGunu;
                stajBilgi.GenelSaglikSigortasi = kullanici.GenelSaglikSigortasi;
                stajBilgi.YasDoldurma = kullanici.YasDoldurma;
                stajBilgi.FirmaAd = kullanici.FirmaAd;
                stajBilgi.FirmaFaaliyetAlani = kullanici.FirmaFaaliyetAlani;
                stajBilgi.FirmaAdres = kullanici.FirmaAdres;
                stajBilgi.FirmaTelefon = kullanici.FirmaTelefon;
                stajListe.Add(stajBilgi);
            }
            

            return stajListe;
        }
    }
}

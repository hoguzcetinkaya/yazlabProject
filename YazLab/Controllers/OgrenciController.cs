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
        public ActionResult StajBasvuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StajBasvuru(BasvuruModel model)
        {
            if(ModelState.IsValid)
            {
                TimeSpan gunFarki = model.StajBitisTarihi - model.StajBaslangicTarihi;
                double gun = gunFarki.TotalDays;
                if( model.IsGunu==30)
                {
                    DataContext db = new DataContext();
                    ApplicationUser kullanici = userManager.FindByName(User.Identity.Name);
                    
                    var basvuru = new BasvuruModel();
                    basvuru.Ad = model.Ad;
                    basvuru.Soyad = model.Soyad;
                    basvuru.TC = model.TC;
                    basvuru.TelefonNumarasi = model.TelefonNumarasi;
                    basvuru.Adres = model.Adres;
                    basvuru.Staj1 = model.Staj1;
                    basvuru.Staj2 = model.Staj2;
                    basvuru.StajDurum = model.StajDurum;
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

        public ActionResult PdfIndex(BasvuruModel model)
        {
            PdfAyarlari pdfAyarlari = new PdfAyarlari();//employeeReport
            byte[] abytes = pdfAyarlari.ReportPdf(GetKullanicilar());
            return File(abytes, "application/Pdf");
        }

        public List<BasvuruModel> GetKullanicilar()
        {
            DataContext db = new DataContext();
            List<BasvuruModel> stajListe = new List<BasvuruModel>();
            BasvuruModel stajBilgi = new BasvuruModel();

            var kullaniciBilgi = userManager.FindByName(User.Identity.Name);
            var kullanici = db.Stajs.FirstOrDefault(x=>x.User_Id==kullaniciBilgi.Id);
            
            for (int i = 0; i < 1; i++)
            {
                stajBilgi.Ad = kullanici.Ad;
                stajBilgi.Soyad = kullanici.Soyad;
                stajBilgi.TC = kullanici.TC;
                stajBilgi.TelefonNumarasi = kullanici.TelefonNumarasi;
                stajBilgi.Adres = kullanici.Adres;
                stajBilgi.StajDurum = kullanici.StajDurum;
                stajBilgi.Staj1 = kullanici.Staj1;
                stajBilgi.Staj2 = kullanici.Staj2;
                if (stajBilgi.Staj1 == true || stajBilgi.Staj2 == false)
                {
                    stajBilgi.StajDurum = "Staj1";
                }
                else if(stajBilgi.Staj2 == true || stajBilgi.Staj1 == false)
                {
                    stajBilgi.StajDurum = "Staj2";
                }
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


        [HttpGet]
        public ActionResult ImeBasvuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImeBasvuru(BasvuruModelime model)
        {
            if (ModelState.IsValid)
            {
                TimeSpan gunFarki = model.ImeBitisTarihi - model.ImeBaslangicTarihi;
                double gun = gunFarki.TotalDays;
                if (model.IsGunu == 30)
                {
                    DataContext db = new DataContext();
                    ApplicationUser kullanici = userManager.FindByName(User.Identity.Name);

                    var basvuruIme = new BasvuruModelime();
                    basvuruIme.Ad = model.Ad;
                    basvuruIme.Soyad = model.Soyad;
                    basvuruIme.TC = model.TC;
                    basvuruIme.TelefonNumarasi = model.TelefonNumarasi;
                    basvuruIme.Adres = model.Adres;
                    basvuruIme.Guz = model.Guz;
                    basvuruIme.Bahar = model.Bahar;
                    basvuruIme.ImeBaslangicTarihi = model.ImeBaslangicTarihi;
                    basvuruIme.ImeBitisTarihi = model.ImeBitisTarihi;
                    basvuruIme.IsGunu = model.IsGunu;
                    basvuruIme.GenelSaglikSigortasi = model.GenelSaglikSigortasi;
                    basvuruIme.YasDoldurma = model.YasDoldurma;
                    basvuruIme.FirmaAd = model.FirmaAd;
                    basvuruIme.FirmaFaaliyetAlani = model.FirmaFaaliyetAlani;
                    basvuruIme.FirmaAdres = model.FirmaAdres;
                    basvuruIme.FirmaTelefon = model.FirmaTelefon;
                    basvuruIme.User_Id = kullanici.Id; //ıme modelinde oluşturduğum user_ıd foreign key
                    db.Imes.Add(basvuruIme);
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

        public ActionResult PdfIndex2(BasvuruModelime model)
        {
            PdfAyarlari2 pdfAyarlari2 = new PdfAyarlari2(); //employeeReport
            byte[] abytes = pdfAyarlari2.ReportPdf(GetKullanicilar2());
            return File(abytes, "application/Pdf");

        }

        public List<BasvuruModelime> GetKullanicilar2()
        {
            DataContext db = new DataContext();
            List<BasvuruModelime> imeListe = new List<BasvuruModelime>();
            BasvuruModelime imeBilgi = new BasvuruModelime();

            var kullaniciBilgi = userManager.FindByName(User.Identity.Name);
            var kullanici = db.Imes.FirstOrDefault(x => x.User_Id == kullaniciBilgi.Id);

            for (int i = 0; i < 1; i++)
            {
                imeBilgi.Ad = kullanici.Ad;
                imeBilgi.Soyad = kullanici.Soyad;
                imeBilgi.TC = kullanici.TC;
                imeBilgi.TelefonNumarasi = kullanici.TelefonNumarasi;
                imeBilgi.Adres = kullanici.Adres;
                imeBilgi.Guz = kullanici.Guz;
                imeBilgi.Bahar = kullanici.Bahar;
                imeBilgi.imeDurum = kullanici.imeDurum;
                if (imeBilgi.Guz == true || imeBilgi.Bahar == false)
                {
                    imeBilgi.imeDurum = "Guz";
                }
                else if (imeBilgi.Bahar == true || imeBilgi.Guz == false)
                {
                    imeBilgi.imeDurum = "Bahar";
                }
                imeBilgi.ImeBaslangicTarihi = kullanici.ImeBaslangicTarihi;
                imeBilgi.ImeBitisTarihi = kullanici.ImeBitisTarihi;
                imeBilgi.IsGunu = kullanici.IsGunu;
                imeBilgi.GenelSaglikSigortasi = kullanici.GenelSaglikSigortasi;
                imeBilgi.YasDoldurma = kullanici.YasDoldurma;
                imeBilgi.FirmaAd = kullanici.FirmaAd;
                imeBilgi.FirmaFaaliyetAlani = kullanici.FirmaFaaliyetAlani;
                imeBilgi.FirmaAdres = kullanici.FirmaAdres;
                imeBilgi.FirmaTelefon = kullanici.FirmaTelefon;
                imeListe.Add(imeBilgi);
            }


            return imeListe;
        }


        public ActionResult RaporGonder()
        {
            return View();
        }

    }
}

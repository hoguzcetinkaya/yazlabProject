using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazLab.Identity;
using YazLab.Models;

namespace YazLab.Controllers
{
    public class KomisyonController : Controller
    {
        // GET: Komisyon
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Staj1OnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Stajs.ToList().Where(x => x.Staj1OnayDurum == false && x.Staj1Durum==true));
        }

        [HttpPost]
        public ActionResult Staj1OnayBekleyenler(int id)
        {
            DataContext db = new DataContext();
            var basvuruStaj1 = new BasvuruModel.Staj();
            var staj1BasvuruOnaylanacakOgrenci = db.Stajs.Single(x=>x.Id==id);
            
            if (staj1BasvuruOnaylanacakOgrenci != null && staj1BasvuruOnaylanacakOgrenci.Staj1Durum==true && staj1BasvuruOnaylanacakOgrenci.Staj1OnayDurum==false)
            {
                staj1BasvuruOnaylanacakOgrenci.Staj1OnayDurum = true;
                db.SaveChanges();

               
            }
            
            return RedirectToAction("Staj1OnayBekleyenler");
            
        }

        [HttpGet]
        public ActionResult Staj2OnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Stajs.ToList().Where(x => x.Staj2OnayDurum == false && x.Staj2Durum == true && x.Staj1Durum==true && x.Staj1OnayDurum==true));
        }

        [HttpPost]
        public ActionResult Staj2OnayBekleyenler(int id)
        {
            DataContext db = new DataContext();
            var basvuruStaj2 = new BasvuruModel.Staj();
            var staj2BasvuruOnaylanacakOgrenci = db.Stajs.Single(x => x.Id == id);

            if (staj2BasvuruOnaylanacakOgrenci != null && staj2BasvuruOnaylanacakOgrenci.Staj2Durum == true && staj2BasvuruOnaylanacakOgrenci.Staj2OnayDurum == false)
            {
                staj2BasvuruOnaylanacakOgrenci.Staj2OnayDurum = true;
                db.SaveChanges();


            }

            return RedirectToAction("Staj2OnayBekleyenler");

        }


        [HttpGet]
        public ActionResult ImeOnayBekleyenler()
        {
            DataContext db = new DataContext();
            return View(db.Imes.ToList().Where(x => x.ImeOnayDurum == false && x.ImeDurum == true));
        }

        [HttpPost]
        public ActionResult ImeOnayBekleyenler(int id)
        {
            DataContext db = new DataContext();
            var ımeBasvuru = new BasvuruModel.Staj();
            var ımeBasvuruOnaylanacakOgrenci = db.Imes.Single(x => x.Id == id);

            if (ımeBasvuruOnaylanacakOgrenci != null && ımeBasvuruOnaylanacakOgrenci.ImeDurum == true && ımeBasvuruOnaylanacakOgrenci.ImeOnayDurum == false)
            {
                ımeBasvuruOnaylanacakOgrenci.ImeOnayDurum = true;
                db.SaveChanges();
            }

            return RedirectToAction("ImeOnayBekleyenler");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YazLab.Models;

namespace YazLab.Controllers
{
    public class OgrenciController : Controller
    {
        //    private DataContext db = new DataContext();

        //    // GET: Ogrenci
        //    public ActionResult Index()
        //    {
        //        var ogrenciler = db.Ogrenciler.Include(o => o.Hoca);
        //        return View(ogrenciler.ToList());
        //    }

        //    // GET: Ogrenci/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Ogrenci ogrenci = db.Ogrenciler.Find(id);
        //        if (ogrenci == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(ogrenci);
        //    }

        //    // GET: Ogrenci/Create
        //    public ActionResult Create()
        //    {
        //        ViewBag.HocaId = new SelectList(db.Hocalar, "Id", "Name");
        //        return View();
        //    }

        //    // POST: Ogrenci/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Create([Bind(Include = "Id,Name,Surname,EMail,Numara,Telefon,Password,Create_Time,Update_Time,HocaId")] Ogrenci ogrenci)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Ogrenciler.Add(ogrenci);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        ViewBag.HocaId = new SelectList(db.Hocalar, "Id", "Name", ogrenci.HocaId);
        //        return View(ogrenci);
        //    }

        //    // GET: Ogrenci/Edit/5
        //    public ActionResult Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Ogrenci ogrenci = db.Ogrenciler.Find(id);
        //        if (ogrenci == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        ViewBag.HocaId = new SelectList(db.Hocalar, "Id", "Name", ogrenci.HocaId);
        //        return View(ogrenci);
        //    }

        //    // POST: Ogrenci/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit([Bind(Include = "Id,Name,Surname,EMail,Numara,Telefon,Password,Create_Time,Update_Time,HocaId")] Ogrenci ogrenci)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            db.Entry(ogrenci).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ViewBag.HocaId = new SelectList(db.Hocalar, "Id", "Name", ogrenci.HocaId);
        //        return View(ogrenci);
        //    }

        //    // GET: Ogrenci/Delete/5
        //    public ActionResult Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Ogrenci ogrenci = db.Ogrenciler.Find(id);
        //        if (ogrenci == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(ogrenci);
        //    }

        //    // POST: Ogrenci/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirmed(int id)
        //    {
        //        Ogrenci ogrenci = db.Ogrenciler.Find(id);
        //        db.Ogrenciler.Remove(ogrenci);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    protected override void Dispose(bool disposing)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
    }
}

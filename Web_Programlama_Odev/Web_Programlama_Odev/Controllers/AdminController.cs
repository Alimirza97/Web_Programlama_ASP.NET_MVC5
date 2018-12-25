using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Programlama_Odev.Models;

namespace Web_Programlama_Odev.Controllers
{
    public class AdminController : Controller
    {
        LeDemyDb db = new LeDemyDb();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori model)
        {
            db.Kategoris.Add(model);
            db.SaveChanges();
            return RedirectToAction("KategoriListele", "Admin");
        }

        public ActionResult KategoriListele()
        {
            var degerler = db.Kategoris.ToList();
            return View(degerler);
        }
        public ActionResult DersDuzenle(int id)
        {
            ViewBag.Kategori_id = new SelectList(db.Kategoris, "Kategori_id", "Kategori_adi");
            var ders = db.Derslers.Where(i => i.Ders_id == id).SingleOrDefault();
            if(ders.Ders_id==id)
                 return View();

            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DersDuzenle(int id,Dersler model)
        {
            var ders = db.Derslers.Where(i => i.Ders_id == id).SingleOrDefault();
            ders.Ders_Adi = model.Ders_Adi;
            ders.Video = model.Video;
            ders.Resim = model.Resim;
            ders.Sure = model.Sure;
            db.SaveChanges();
            return RedirectToAction("DersListele", "Admin");
        }
        public ActionResult DersSil(int id)
        {
            var silinecekdegerial = db.Derslers.Where(i => i.Ders_id == id).SingleOrDefault();
            db.Derslers.Remove(silinecekdegerial);
            db.SaveChanges();
            return RedirectToAction("DersListele","Admin");
        }
        public ActionResult DersEkle()
        {
            ViewBag.Kategori_id = new SelectList(db.Kategoris, "Kategori_id", "Kategori_adi");
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Dersler model)
        {
            db.Derslers.Add(model);
            db.SaveChanges();
            return RedirectToAction("DersListele", "Admin");
        }
        public ActionResult DersListele()
        {
            var degerler = db.Derslers.ToList();
            return View(degerler);
        }
        public ActionResult UyeListele()
        {
            var degerler = db.Uyelers.ToList();
            return View(degerler);
        }
        public ActionResult UyeSil(int id)
        {
            var silinecekdegerial = db.Uyelers.Where(i => i.UyeId == id).SingleOrDefault();
            db.Uyelers.Remove(silinecekdegerial);
            db.SaveChanges();
            return RedirectToAction("UyeListele", "Admin");
        }
    }
}

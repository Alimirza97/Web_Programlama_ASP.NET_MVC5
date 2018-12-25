using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Programlama_Odev.Models;
namespace Web_Programlama_Odev.Controllers
{
    public class KullaniciController : YetkiController
    {
        LeDemyDb db = new LeDemyDb();

        // GET: Kullanici
        public ActionResult Index()
        {
            return View();
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kullanici/Create
        
        
        public ActionResult LogOut()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
        // GET: Kullanici/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Uyeler model)
        {
            try
            {
                var kullanici = db.Uyelers.Where(i => i.UyeId == id).SingleOrDefault();
                kullanici.UyeAd = model.UyeAd;
                kullanici.UyeSoyad = model.UyeSoyad;
                kullanici.UyeSifre = model.UyeSifre;
                kullanici.KullaniciAdi = model.KullaniciAdi;
                db.SaveChanges();
                return RedirectToAction("Profile","Kullanici");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Profile()
        {
            string uyeadi = Session["username"].ToString();
            var kullanici = db.Uyelers.Where(i => i.UyeAd == uyeadi).SingleOrDefault();
            return View(kullanici);
        }
        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kullanici/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Programlama_Odev.Models;

namespace Web_Programlama_Odev.Controllers
{
    public class HomeController : Controller
    {
        LeDemyDb db = new LeDemyDb();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DersDetay(int id)
        {
            var dbdeger = db.Derslers.Where(i => i.Ders_id == id).SingleOrDefault();
            dbdeger.IzlenmeSayisi++;
            db.SaveChanges();
            return View(dbdeger);
        }
        public ActionResult JavaScript()
        {
            var java = db.Derslers.Where(i => i.Kategori_id == 2).ToList();
            return View(java);
        }
        public ActionResult Cpp()
        {
            var cpp = db.Derslers.Where(i => i.Kategori_id == 3).ToList();
            return View(cpp);
        }
        public ActionResult Css()
        {
            var css = db.Derslers.Where(i => i.Kategori_id == 4).ToList();
            return View(css);
        }
        public ActionResult WebDesign()
        {
            var web = db.Derslers.Where(i => i.Kategori_id == 1).ToList();
            return View(web);
        }
        public ActionResult Kaydol()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Iletisim()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(Uyeler model)
        {
            try
            {
                var dbdeger = db.Uyelers.Where(i => i.UyeId == model.UyeId).SingleOrDefault();
                if (dbdeger != null)
                {
                    return View();
                }
                if (string.IsNullOrEmpty(model.UyeSifre))
                {
                    return View();
                }
                db.Uyelers.Add(model);
                model.YektiId = 1;
                Session["username"] = model.UyeAd;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Uyeler model)
        {
            try
            {
                var dbdeger = db.Uyelers.Where(i => i.UyeEmail == model.UyeEmail).SingleOrDefault();
                if (dbdeger == null)
                {
                    return View();
                }
                if (dbdeger.UyeEmail==model.UyeEmail && dbdeger.UyeSifre == model.UyeSifre && dbdeger.YektiId == 1)
                {
                    Session["username"] = dbdeger.UyeAd;
                    Session["userid"] = dbdeger.UyeId;
                    return RedirectToAction("Index", "Home");
                }
                if (dbdeger.UyeEmail == model.UyeEmail && dbdeger.UyeSifre == model.UyeSifre && dbdeger.YektiId == 2)
                {
                    Session["username"] = dbdeger.UyeAd;
                    return RedirectToAction("Index", "Admin");
                }
                return View();
            }
            catch (Exception)
            {

                return View();
            }

        }
       
        public ActionResult AdminLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn(Uyeler model)
        {
            try
            {
                var kullanici = db.Uyelers.Where(i => i.UyeEmail == model.UyeEmail).SingleOrDefault();
                if(kullanici==null)
                {
                    return View();
                }
                if(kullanici.UyeEmail==model.UyeEmail && kullanici.UyeSifre==model.UyeSifre && kullanici.YektiId>1)
                {
                    Session["yetkiid"] = kullanici.YektiId;
                    Session["username"] = kullanici.UyeAd;
                    Session["userid"] = kullanici.UyeId;
                    return RedirectToAction("Index", "Admin");
                }

                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
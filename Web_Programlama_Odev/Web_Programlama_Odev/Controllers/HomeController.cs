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
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Popular()
        {
            return View();
        }
        public ActionResult JavaScript()
        {
            return View();
        }
        public ActionResult Cpp()
        {
            return View();
        }
        public ActionResult Css()
        {
            return View();
        }
        public ActionResult Kaydol()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        public ActionResult WebDesign()
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
                if (dbdeger.UyeSifre == model.UyeSifre)
                {
                    Session["username"] = dbdeger.UyeAd;
                    Session["userid"] = dbdeger.UyeId;
                    return RedirectToAction("Index", "Home");
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
                if(kullanici.UyeSifre==model.UyeSifre && kullanici.YektiId==2)
                {
                    Session["username"] = model.UyeAd;
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
using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AdminGaleriController : Controller
    {
        // GET: AdminGaleri
        GaleriManager gm = new GaleriManager(new EfGaleriDal());
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var galeris = gm.Getlist();
            return View(galeris);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Galeri galeri)
        {
            GaleriValidator galeriValidator = new GaleriValidator();
            ValidationResult results = galeriValidator.Validate(galeri);

            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    galeri.GaleriImage = "/Image/" + dosyaAdi + uzanti;
                }
                gm.GaleriAdd(galeri);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(galeri);
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var galerivalue = gm.GetBuyID(id);
            return View(galerivalue);
        }

        [HttpPost]
        public ActionResult Edit(Galeri galeri)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                galeri.GaleriImage = "/Image/" + dosyaAdi + uzanti;
            }
            gm.EditGaleri(galeri);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hizmetlervalues = gm.GetBuyID(id);
            gm.DeleteGaleri(hizmetlervalues);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleStatus(int id)
        {
            gm.GaleriToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
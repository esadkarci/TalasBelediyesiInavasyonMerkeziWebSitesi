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
    public class AdminHaberlerController : Controller
    {
        HaberlerManager hm = new HaberlerManager(new EfHaberlerDal());
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var haberlers= hm.Getlist();
            return View(haberlers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Haberler haberler)
        {

            HaberlerValidator haberlerValidator = new HaberlerValidator();
            ValidationResult results = haberlerValidator.Validate(haberler);

            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    haberler.HaberImage = "/Image/" + dosyaAdi + uzanti;
                }
                hm.HaberlerAdd(haberler);
                return RedirectToAction("Index");               
            
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(haberler);
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var haberlervalue = hm.GetBuyID(id);
            return View(haberlervalue);
        }

        [HttpPost]
        public ActionResult Edit(Haberler haberler)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                haberler.HaberImage = "/Image/" + dosyaAdi + uzanti;
            }
            hm.EditHaberler(haberler);
            return RedirectToAction("Index");
        }
    
        public ActionResult Delete(int id)
        {
            var haberlervalues = hm.GetBuyID(id);
            hm.DeleteHaberler(haberlervalues);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleStatus(int id)
        {
            hm.HaberlerToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
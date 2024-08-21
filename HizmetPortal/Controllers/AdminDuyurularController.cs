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
    public class AdminDuyurularController : Controller
    {
        // GET: AdminDuyurular
        DuyurularManager dm = new DuyurularManager(new EfDuyurularDal());
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var duyurulars = dm.Getlist();
            return View(duyurulars);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Duyurular duyurular)
        {
            DuyurularValidator duyurularValidator = new DuyurularValidator();
            ValidationResult results = duyurularValidator.Validate(duyurular);

            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    duyurular.DuyurularImage = "/Image/" + dosyaAdi + uzanti;
                }
                dm.DuyurularAdd(duyurular);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(duyurular);
            }         
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var duyurularvalue = dm.GetBuyID(id);
            return View(duyurularvalue);
        }

        [HttpPost]
        public ActionResult Edit(Duyurular duyurular)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                duyurular.DuyurularImage = "/Image/" + dosyaAdi + uzanti;
            }
            dm.EditDuyurular(duyurular);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hizmetlervalues = dm.GetBuyID(id);
            dm.DeleteDuyurular(hizmetlervalues);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleStatus(int id)
        {
            dm.DuyurularToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
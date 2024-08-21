using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AdminHizmetlerController : Controller
    {
        HizmetlerManager hm = new HizmetlerManager(new EfHizmetlerDal());
        Context context =new Context();
        [Authorize]
        public ActionResult Index()
        {
            var hizmetlers = hm.HizmetlerGetAll();
            return View(hizmetlers);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hizmetler hizmetler)
        {
            HizmetlerValidator hizmetlerValidator = new HizmetlerValidator();
            ValidationResult results = hizmetlerValidator.Validate(hizmetler);

            if (results.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0] != null)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    hizmetler.HizmetImage = "/Image/" + dosyaAdi + uzanti;
                }

                if (Request.Files.Count > 1 && Request.Files["HizmetIconFile"] != null)
                {
                    string iconFileName = Path.GetFileNameWithoutExtension(Request.Files["HizmetIconFile"].FileName);
                    string iconExtension = Path.GetExtension(Request.Files["HizmetIconFile"].FileName);
                    string iconPath = "~/Icon/" + iconFileName + iconExtension;
                    Request.Files["HizmetIconFile"].SaveAs(Server.MapPath(iconPath));
                    hizmetler.HizmetIcon = "/Icon/" + iconFileName + iconExtension;
                }

                hm.HizmetlerAdd(hizmetler);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(hizmetler);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var hizmetlervalue = hm.HizmetlerGetById(id);
            return View(hizmetlervalue);
        }

        [HttpPost]
        public ActionResult Edit(Hizmetler hizmetler)
        {
            if (Request.Files.Count > 0 && Request.Files["HizmetlerImage"] != null)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files["HizmetlerImage"].FileName);
                string uzanti = Path.GetExtension(Request.Files["HizmetlerImage"].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files["HizmetlerImage"].SaveAs(Server.MapPath(yol));
                hizmetler.HizmetImage = "/Image/" + dosyaAdi + uzanti;
            }

            if (Request.Files.Count > 0 && Request.Files["HizmetIconFile"] != null)
            {
                string iconFileName = Path.GetFileNameWithoutExtension(Request.Files["HizmetIconFile"].FileName);
                string iconExtension = Path.GetExtension(Request.Files["HizmetIconFile"].FileName);
                string iconPath = "~/Icon/" + iconFileName + iconExtension;
                Request.Files["HizmetIconFile"].SaveAs(Server.MapPath(iconPath));
                hizmetler.HizmetIcon = "/Icon/" + iconFileName + iconExtension;
            }
            hm.HizmetlerUpdate(hizmetler);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            hm.HizmetlerToggleStatus(id);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hizmetlervalues = hm.HizmetlerGetById(id);
            hm.HizmetlerDelete(hizmetlervalues);
            return RedirectToAction("Index");
        }
    }
}
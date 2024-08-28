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
        Context context = new Context();
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
            if (Request.Files.Count > 0 && Request.Files[0] != null)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                hizmetler.HizmetImage = "/Image/" + dosyaAdi + uzanti;
            }

            hm.HizmetlerAdd(hizmetler);
            return RedirectToAction("Index");
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
            if (Request.Files.Count > 0 && Request.Files["HizmetImage"] != null)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files["HizmetImage"].FileName);
                string uzanti = Path.GetExtension(Request.Files["HizmetImage"].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files["HizmetImage"].SaveAs(Server.MapPath(yol));
                hizmetler.HizmetImage = "/Image/" + dosyaAdi + uzanti;
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
using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                hizmetler.HizmetImage = "/Image/" + dosyaAdi + uzanti;
            }
            if (Request.Files.Count > 0 && Request.Files["HizmetIconFile"] != null)
            {
                string iconFileName = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string iconExtension = Path.GetExtension(Request.Files[0].FileName);
                string iconPath = "~/Icon/" + iconFileName + iconExtension;
                Request.Files["HizmetIconFile"].SaveAs(Server.MapPath(iconPath));
                hizmetler.HizmetIcon = "/Icon/" + iconFileName + iconExtension;
            }
            // Add hizmetler to database

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
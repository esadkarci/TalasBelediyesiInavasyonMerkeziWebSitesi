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
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                duyurular.DuyurularImage = "/Image/" + dosyaAdi + uzanti;
            }

            // Add hizmetler to database

            dm.DuyurularAdd(duyurular);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var hizmetlervalue = dm.GetBuyID(id);
            return View(hizmetlervalue);
        }

        [HttpPost]
        public ActionResult Edit(Duyurular duyurular)
        {
            dm.EditDuyurular(duyurular);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hizmetlervalues = dm.GetBuyID(id);
            dm.DeleteDuyurular(hizmetlervalues);
            return RedirectToAction("Index");
        }
    }
}
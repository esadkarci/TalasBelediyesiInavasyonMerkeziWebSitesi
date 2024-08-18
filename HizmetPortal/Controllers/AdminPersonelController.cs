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
    public class AdminPersonelController : Controller
    {

        // GET: AdminPersonel
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var personels = pm.GetAll();
            return View(personels);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelImage = "/Image/" + dosyaAdi + uzanti;
            }
            pm.Add(personel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var personelvalue = pm.PersonelGetById(id);
            return View(personelvalue);
        }

        [HttpPost]
        public ActionResult Edit(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelImage = "/Image/" + dosyaAdi + uzanti;
            }
            pm.PersonelUpdate(personel);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var personelvalues = pm.PersonelGetById(id);
            pm.PersonelDelete(personelvalues);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleStatus(int id)
        {
            pm.PersonelToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
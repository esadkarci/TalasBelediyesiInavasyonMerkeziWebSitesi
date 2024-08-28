using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: Duyurular
        DuyurularManager dm = new DuyurularManager(new EfDuyurularDal());
        HizmetlerManager hm = new HizmetlerManager(new EfHizmetlerDal());
        LessonManager lm = new LessonManager(new EfLessonDal());
        GaleriManager gm = new GaleriManager(new EfGaleriDal());


        public ActionResult AnaSayfaIndex()
        {
            return View();
        }
        public ActionResult DuyurlarIndex()
        {
            var duyurulars = dm.Getlist();
            return View(duyurulars);
        }
        public ActionResult HizmetIndex()
        {
            var hizmetlers = hm.HizmetlerGetAll();
            return View(hizmetlers);
        }
        public ActionResult HizmetlerIndex()
        {
            var hizmetlers = hm.HizmetlerGetAll();
            return View(hizmetlers);
        }
        public ActionResult DersIndex()
        {
            var lessons = lm.LessonGetAll();
            return View(lessons);
        }
        public ActionResult GaleriIndex()
        {
            var galeris = gm.Getlist();
            return View(galeris);
        }
    }
}
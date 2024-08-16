using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class ProjelerController : Controller
    {
        // GET: Projeler
        ProjectManager pm = new ProjectManager(new EfProjectDal());
        public ActionResult Index()
        {
            var projelers = pm.ProjectGetAll();
            return View(projelers);           
        }
        public ActionResult YapılmasıPlananProjelerIndex()
        {
            var projelers = pm.ProjectGetAll();
            return View(projelers);
        }
        public ActionResult YapımıDevamEdenProjelerIndex()
        {
            var projelers = pm.ProjectGetAll();
            return View(projelers);
        }
        public ActionResult YapımıTamamlananProjelerIndex()
        {
            var projelers = pm.ProjectGetAll();
            return View(projelers);
        }
        public ActionResult ProjelerDetaylarIndex(int id)
        {
            var projelers = pm.ProjectGetById(id);
            return View(projelers);
        }
    }
}
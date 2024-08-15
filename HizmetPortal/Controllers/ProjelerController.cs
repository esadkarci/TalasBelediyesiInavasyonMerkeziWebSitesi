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
            var personels = pm.ProjectGetAll();
            return View(personels);           
        }
    }
}
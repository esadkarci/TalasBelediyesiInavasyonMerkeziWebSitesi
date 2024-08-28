using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        GaleriManager gm = new GaleriManager(new EfGaleriDal());
        public ActionResult Index()
        {
            var galeris = gm.Getlist();
            return View(galeris);
        }
    }
}
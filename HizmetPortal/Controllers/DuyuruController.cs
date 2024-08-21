using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class DuyuruController : Controller
    {
        DuyurularManager dm = new DuyurularManager(new EfDuyurularDal());
        // GET: Duyuru
        public ActionResult Index()
        {
            var duyurulars = dm.Getlist();
            return View(duyurulars);
        }
    }
}
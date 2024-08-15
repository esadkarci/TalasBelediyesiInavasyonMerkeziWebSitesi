using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class DuyurularController : Controller
    {
        // GET: Duyurular
        DuyurularManager dm = new DuyurularManager(new EfDuyurularDal());
        HizmetlerManager hm=new HizmetlerManager(new EfHizmetlerDal());
        public ActionResult AnaIndex()
        {
            return View();
        }
        public ActionResult DuyurlarIndex()
        {
            var duyurulars = dm.Getlist();
            return View(duyurulars);
        }
        public ActionResult HizmetlerIndex()
        {
            var hizmetlers = hm.HizmetlerGetAll();
            return View(hizmetlers);
        }
    }
}
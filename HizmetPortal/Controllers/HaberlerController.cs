using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace HizmetPortal.Controllers
{
    public class HaberlerController : Controller
    {
        // GET: Haberler
        HaberlerManager hm = new HaberlerManager(new EfHaberlerDal());
        public ActionResult Index(int p = 1)
        {
            var haberlers = hm.Getlist().ToPagedList(p, 9);
            return View(haberlers);
        }
        public ActionResult HaberDetailsIndex(int id)
        {
            var haberlervalues = hm.GetBuyID(id);
            return View(haberlervalues);
        }
    }
}
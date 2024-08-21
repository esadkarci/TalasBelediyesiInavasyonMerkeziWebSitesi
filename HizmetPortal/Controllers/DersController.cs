using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class DersController : Controller
    {
        LessonManager lm = new LessonManager(new EfLessonDal());
        // GET: Ders
        public ActionResult Index()
        {
            var lessons = lm.LessonGetAll();
            return View(lessons);
        }
    }
}
using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        LessonManager lm = new LessonManager(new EfLessonDal());
        public ActionResult Index()
        {
            var lessons = lm.LessonGetAll();
            return View(lessons);
        }
        public ActionResult LessonDetaylarIndex(int id)
        {
            var lessons = lm.LessonGetById(id);
            return View(lessons);
        }
    }
}
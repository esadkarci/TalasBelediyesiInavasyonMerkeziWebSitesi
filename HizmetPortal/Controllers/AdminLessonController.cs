using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AdminLessonController : Controller
    {
        LessonManager lm = new LessonManager(new EfLessonDal());
        Context context = new Context();
        [Authorize]
        // GET: AdminLesson
        public ActionResult Index()
        {
            var lessons = lm.LessonGetAll();
            return View(lessons);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Lesson lesson)
        {
            LessonValidator lessonValidator = new LessonValidator();
            ValidationResult results = lessonValidator.Validate(lesson);
            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    lesson.LessonImage = "/Image/" + dosyaAdi + uzanti;
                }

                lm.LessonAdd(lesson);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(lesson);
            }
           
           
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lessonvalue = lm.LessonGetById(id);
            return View(lessonvalue);
        }

        [HttpPost]
        public ActionResult Edit(Lesson lesson)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                lesson.LessonImage = "/Image/" + dosyaAdi + uzanti;
            }
            lm.LessonUpdate(lesson);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            lm.LessonToggleStatus(id);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hizmetlervalues = lm.LessonGetById(id);
            lm.LessonDelete(hizmetlervalues);
            return RedirectToAction("Index");
        }
    }
}
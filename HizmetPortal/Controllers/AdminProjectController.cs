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
    public class AdminProjectController : Controller
    {
        ProjectManager pm = new ProjectManager(new EfProjectDal());
        StageManager sm = new StageManager(new EfStageDal());
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var projects = pm.ProjectGetAll();
            return View(projects);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Stages = sm.StageGetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            ProjectValidator projectValidator = new ProjectValidator();
            ValidationResult results = projectValidator.Validate(project);

            if (results.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/Image/" + dosyaAdi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    project.ProjectImage = "/Image/" + dosyaAdi + uzanti;
                }


                pm.ProjectAdd(project);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(project);
            }         
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var projectvalue = pm.ProjectGetById(id);
            ViewBag.Stages = sm.StageGetAll(); // Bu satır eksik.
            return View(projectvalue);
        }

        [HttpPost]
        public ActionResult Edit(Project project)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                project.ProjectImage = "/Image/" + dosyaAdi + uzanti;
            }
            pm.ProjectUpdate(project);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            pm.ProjectToggleStatus(id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var projectvalue = pm.ProjectGetById(id);
            pm.ProjectDelete(projectvalue);
            return RedirectToAction("Index");
        }
    }
}
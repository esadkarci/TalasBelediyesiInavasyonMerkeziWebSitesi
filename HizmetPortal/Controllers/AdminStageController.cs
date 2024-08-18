using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
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
    public class AdminStageController : Controller
    {
        StageManager sm = new StageManager(new EfStageDal());
        [Authorize]
        // GET: AdminStage
        public ActionResult Index()
        {
            var stages = sm.StageGetAll();
            return View(stages);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stage stage)
        {
            StageValidator stageValidator = new StageValidator();
            ValidationResult results = stageValidator.Validate(stage);

            if (results.IsValid)
            {
                sm.StageAdd(stage);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(stage);
            }

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var stagevalue = sm.StageGetById(id);
            return View(stagevalue);
        }

        [HttpPost]
        public ActionResult Edit(Stage stage)
        {
            sm.StageUpdate(stage);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            sm.StageToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
using BusinessLayer_HizmetPortal.Abstract;
using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AdminServiceController : Controller
    {
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        public ActionResult Index()
        {
            var services = sm.GetAll();
            return View(services);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Service service)
        {
            ServiceValidation serviceValidation = new ServiceValidation();
            ValidationResult results = serviceValidation.Validate(service);

            if (results.IsValid)
            {
                sm.Add(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var failure in results.Errors)
                {
                    ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return View(service);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var servicevalue = sm.ServiceGetById(id);
            return View(servicevalue);
        }

        [HttpPost]
        public ActionResult Edit(Service service)
        {
            sm.ServiceUpdate(service);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            sm.ToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
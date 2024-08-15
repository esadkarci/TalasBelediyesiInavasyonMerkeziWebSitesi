using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class EventController : Controller
    {
        EventMManager em = new EventMManager(new EfEventDal());
        public ActionResult Index()
        {
            var events = em.GetAll();
            return View(events);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event events)
        {
            em.Add(events);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var eventvalues = em.EventGetById(id);
            return View(eventvalues);
        }

        [HttpPost]
        public ActionResult Edit(Event eventssas)
        {
            em.EventUpdate(eventssas);
            return RedirectToAction("Index");
        }

        public ActionResult ToggleStatus(int id)
        {
            em.ToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
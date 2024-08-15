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
    public class AdminUserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            var users = um.GetAll();
            return View(users);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            um.Add(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var uservalue = um.UserGetById(id);
            return View(uservalue);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            um.UserUpdate(user);
            return RedirectToAction("Index");
        }
        public ActionResult ToggleStatus(int id)
        {
            um.ToggleStatus(id);
            return RedirectToAction("Index");
        }
    }
}
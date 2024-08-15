using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        PersonelManager pm = new PersonelManager(new EfPersonelDal());
        public ActionResult Index()
        {
            var personels = pm.GetAll();
            return View(personels);
        }
        public ActionResult PersonelDetailsIndex(int id)
        {
            var personelvalues = pm.PersonelGetById(id);
            return View(personelvalues);
        }
    }
}
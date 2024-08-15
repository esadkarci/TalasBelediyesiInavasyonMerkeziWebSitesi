using DataAcessLayer_HizmetPortal.Concrate;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HizmetPortal.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context context= new Context();
            var adminuserinfo = context.Admins.FirstOrDefault(x=>x.AdminMail == p.AdminMail && x.AdminPassword==p.AdminPassword);
            if (adminuserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminMail, false);
                Session["AdminMail"] = adminuserinfo.AdminMail;
                return RedirectToAction("Index","AdminPersonel");
            }
            else
            {

                TempData["ErrorMessage"] = "Gecersiz kullanıcı adı veya sifre.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
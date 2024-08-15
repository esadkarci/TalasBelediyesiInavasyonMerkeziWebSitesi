using BusinessLayer_HizmetPortal.Abstract;
using BusinessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HizmetPortal.Controllers
{
    public class AdminRandevuController : Controller
    {
        ServiceAppointment sa = new ServiceAppointment(new EfAppointmentDal());
        ServiceManager sm = new ServiceManager(new EfServiceDal());
        UserManager um =new UserManager(new EfUserDal());
        public ActionResult Index()
        {
            var appointments = sa.GetAll();
            return View(appointments);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Users=um.GetAll();
            ViewBag.Services = sm.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Appointment appointment, string AppointmentTime)
        {
            // Combine the selected date and time into a single DateTime object
            if (DateTime.TryParseExact(AppointmentTime, "HH:mm", null, System.Globalization.DateTimeStyles.None, out var time))
            {
                appointment.AppointmentStartTime = appointment.AppointmentStartTime.Date.Add(time.TimeOfDay);
            }
            else
            {
                ModelState.AddModelError("", "Invalid time format.");
                ViewBag.Services = sm.GetAll();
                ViewBag.Users = um.GetAll();
                return View(appointment);
            }

            // Check for existing appointments at the same exact datetime
            var existingAppointment = sa.GetAll().FirstOrDefault(a =>
                a.AppointmentStartTime == appointment.AppointmentStartTime);

            if (existingAppointment != null)
            {
                ModelState.AddModelError("", "An appointment already exists at this date and time.");
                ViewBag.Services = sm.GetAll();
                ViewBag.Users = um.GetAll();
                return View(appointment);
            }
           
            // Assign a fixed user ID
           

            sa.Add(appointment);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteRandevu(int id)
        {
            var appointmentvalues = sa.AppointmentGetById(id);
            sa.Sil(appointmentvalues);
            return RedirectToAction("Index");
        }

    }
}
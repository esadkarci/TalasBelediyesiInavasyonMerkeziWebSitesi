using BusinessLayer_HizmetPortal.Abstract;
using BusinessLayer_HizmetPortal.Concrate;
using BusinessLayer_HizmetPortal.ValidationRules;
using DataAcessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Concrate;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace HizmetPortal.Controllers
{
    public class AdminReservationController : Controller
    {
        private readonly ReservationManager _reservationManager;
        private readonly EventMManager _eventManager;
        UserManager um = new UserManager(new EfUserDal());
        
        public AdminReservationController()
        {
            _reservationManager = new ReservationManager(new EfReservationDal());
            _eventManager = new EventMManager(new EfEventDal());
        }

        public ActionResult Index()
        {
            var events = _eventManager.GetAll();
            return View(events);
        }

        public ActionResult ViewReservations(int eventId)
        {
            var reservations = _reservationManager.GetAll().Where(r => r.EventId == eventId).ToList();
            ViewBag.EventId = eventId; // Pass EventId to the view if needed
            return View(reservations);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Users = um.GetAll();
            ViewBag.Events = _eventManager.GetAll();
            return View();
        }

        // POST: AdminReservation/Create
        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            reservation.ReservationDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            _reservationManager.Add(reservation);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReservation(int reservationId, int eventId)
        {
            var reservation = _reservationManager.GetById(reservationId);
            if (reservation != null)
            {
                _reservationManager.Delete(reservation);
            }
            return RedirectToAction("ViewReservations", new { eventId = eventId });
        }
    }
}

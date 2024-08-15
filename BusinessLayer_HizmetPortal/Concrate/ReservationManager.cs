using BusinessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Concrate
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Add(Reservation reservation)
        {
            _reservationDal.Add(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _reservationDal.Delete(reservation);
        }

        public List<Reservation> GetAll()
        {
            return _reservationDal.List();
        }

        public Reservation GetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> List(Expression<Func<Reservation, bool>> filter)
        {
            return _reservationDal.FiltreList(filter);
        }
    }
}

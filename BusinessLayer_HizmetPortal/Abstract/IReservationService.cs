using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IReservationService
    {
        void Add(Reservation reservation);
        void Delete(Reservation reservation);
        Reservation GetById(int id);
        List<Reservation> GetAll();
        List<Reservation> List(Expression<Func<Reservation, bool>> filter);
    }
}

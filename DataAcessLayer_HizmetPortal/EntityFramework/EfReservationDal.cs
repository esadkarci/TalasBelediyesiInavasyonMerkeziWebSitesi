using DataAcessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Concrate.Repositories;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer_HizmetPortal.EntityFramework
{
    public class EfReservationDal :GenericRepository<Reservation>,IReservationDal
    {
    }
}

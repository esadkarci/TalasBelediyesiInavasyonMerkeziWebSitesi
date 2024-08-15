using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IAppointmentService
    {
        void Add(Appointment appointment);
        void AppointmentUpdate(Appointment appointment);
        Appointment AppointmentGetById(int id);
        List<Appointment> GetAll();

        void Sil(Appointment appointment);
       
    }
}

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
    public class ServiceAppointment :IAppointmentService
    {
        IAppointmentDal _appointmentdal;

        public ServiceAppointment(IAppointmentDal appointmentdal)
        {
            _appointmentdal = appointmentdal;
        }

        public void Add(Appointment appointment)
        {
            _appointmentdal.Add(appointment);
        }


        public Appointment AppointmentGetById(int id)
        {
            return _appointmentdal.Get(x => x.AppointmentId == id);
        }

        public void AppointmentUpdate(Appointment appointment)
        {
            _appointmentdal.Update(appointment);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentdal.List();
        }

        public void Sil(Appointment appointment)
        {
            _appointmentdal.Delete(appointment);
        }

        
    }
}

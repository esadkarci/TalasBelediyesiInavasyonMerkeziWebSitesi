using BusinessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Abstract;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Concrate
{
    public class ServiceManager : IServiceService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal servicedal)
        {
            _serviceDal = servicedal;
        }

        public void Add(Service service)
        {
            _serviceDal.Add(service);
        }

        public void ServiceUpdate(Service service)
        {
            _serviceDal.Update(service);
        }

        public Service ServiceGetById(int id)
        {
            return _serviceDal.Get(x => x.ServiceId == id);
        }

        public void ToggleStatus(int id)
        {
            var service = _serviceDal.GetById(id);
            if (service != null)
            {
                service.ServiceStatues = !service.ServiceStatues;
                _serviceDal.Update(service);
            }
        }

        public List<Service> GetAll()
        {
            return _serviceDal.List();
        }
    }
}

using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IServiceService
    {
        void Add(Service service);
        void ServiceUpdate(Service service);
        Service ServiceGetById(int id);
        List<Service> GetAll();
        void ToggleStatus(int id);
    }

}

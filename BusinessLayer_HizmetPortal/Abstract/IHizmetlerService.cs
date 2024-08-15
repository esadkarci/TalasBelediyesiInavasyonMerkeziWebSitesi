using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IHizmetlerService
    {
        void HizmetlerAdd(Hizmetler hizmetler);
        void HizmetlerUpdate(Hizmetler hizmetler);
        Hizmetler HizmetlerGetById(int id);
        List<Hizmetler> HizmetlerGetAll();
        void HizmetlerToggleStatus(int id);
        void HizmetlerDelete(Hizmetler hizmetler);
    }
}

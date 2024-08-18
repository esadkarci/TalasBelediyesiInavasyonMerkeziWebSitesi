using BusinessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.Abstract;
using DataAcessLayer_HizmetPortal.EntityFramework;
using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Concrate
{
    public class HizmetlerManager:IHizmetlerService
    {
        IHizmetlerDal _hizmetlerdal;

        public HizmetlerManager(IHizmetlerDal hizmetlerdal)
        {
            _hizmetlerdal = hizmetlerdal;
        }

        public void HizmetlerAdd(Hizmetler hizmetler)
        {
            _hizmetlerdal.Add(hizmetler);
        }

        public void HizmetlerDelete(Hizmetler hizmetler)
        {
            _hizmetlerdal.Delete(hizmetler);
        }

        public List<Hizmetler> HizmetlerGetAll()
        {
            return _hizmetlerdal.List();
        }

        public Hizmetler HizmetlerGetById(int id)
        {
            return _hizmetlerdal.Get(x => x.HizmetId == id);
        }

        public void HizmetlerToggleStatus(int id)
        {
            var hizmet = _hizmetlerdal.GetById(id);
            if (hizmet != null)
            {
                hizmet.HizmetStatus = !hizmet.HizmetStatus;
                _hizmetlerdal.Update(hizmet);
            }
        }

        public void HizmetlerUpdate(Hizmetler hizmetler)
        {
            _hizmetlerdal.Update(hizmetler);
        }
    }
}

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
    public class DuyurularManager : IDuyurularService
    {
        IDuyurularDal _duyurularDal;

        public DuyurularManager(IDuyurularDal duyurularDal)
        {
            _duyurularDal = duyurularDal;
        }

        public void DeleteDuyurular(Duyurular duyurular)
        {
            _duyurularDal.Delete(duyurular);
        }

        public void DuyurularAdd(Duyurular duyurular)
        {
            _duyurularDal.Add(duyurular);
        }

        public void DuyurularToggleStatus(int id)
        {
            var duyurlar = _duyurularDal.GetById(id);
            if (duyurlar != null)
            {
                duyurlar.DuyurularStatus = !duyurlar.DuyurularStatus;
                _duyurularDal.Update(duyurlar);
            }
        }

        public void EditDuyurular(Duyurular duyurular)
        {
            _duyurularDal.Update(duyurular);
        }

        public Duyurular GetBuyID(int id)
        {
            return _duyurularDal.Get(x => x.DuyurularId == id);
        }

        public List<Duyurular> Getlist()
        {
            return _duyurularDal.List();
        }
    }
}

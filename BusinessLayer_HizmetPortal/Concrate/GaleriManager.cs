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
    public class GaleriManager : IGaleriService
    {
        IGaleriDal _galeriDal;

        public GaleriManager(IGaleriDal galeriDal)
        {
            this._galeriDal = galeriDal;

        }

        public void DeleteGaleri(Galeri galeri)
        {
            _galeriDal.Delete(galeri);
        }

        public void EditGaleri(Galeri galeri)
        {
            _galeriDal.Update(galeri);
        }

        public void GaleriAdd(Galeri galeri)
        {
            _galeriDal.Add(galeri);
        }

        public void GaleriToggleStatus(int id)
        {
            var galeri = _galeriDal.GetById(id);
            if (galeri != null)
            {
                galeri.GaleriStatus = !galeri.GaleriStatus;
                _galeriDal.Update(galeri);
            }
        }

        public Galeri GetBuyID(int id)
        {
            return _galeriDal.Get(x => x.GaleriId == id);
        }

        public List<Galeri> Getlist()
        {
            return _galeriDal.List();
        }
    }
}

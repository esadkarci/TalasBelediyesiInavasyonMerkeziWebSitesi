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
    public class HaberlerManager : IHaberlerService

    {

        IHaberlerDal _haberlerdal;

        public HaberlerManager(IHaberlerDal haberlerdal)
        {
            _haberlerdal = haberlerdal;
        }

        public void DeleteHaberler(Haberler haberler)
        {
            _haberlerdal.Delete(haberler);
        }

        public void EditHaberler(Haberler haberler)
        {
            _haberlerdal.Update(haberler);
        }

        public Haberler GetBuyID(int id)
        {
            return _haberlerdal.Get(x => x.HaberId == id);
        }

        public List<Haberler> Getlist()
        {
            return _haberlerdal.List().OrderByDescending(h => h.HaberDate).ToList();
        }

        public void HaberlerAdd(Haberler haberler)
        {
            _haberlerdal.Add(haberler);
        }
    }
}

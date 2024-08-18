using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IHaberlerService
    {
        List<Haberler> Getlist();
        void HaberlerAdd(Haberler haberler);
        Haberler GetBuyID(int id);
        void DeleteHaberler(Haberler haberler);
        void EditHaberler(Haberler haberler);
        void HaberlerToggleStatus(int id);
    }
}


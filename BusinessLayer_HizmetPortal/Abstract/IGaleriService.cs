using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IGaleriService
    {
        List<Galeri> Getlist();
        void GaleriAdd(Galeri galeri);
        Galeri GetBuyID(int id);
        void DeleteGaleri(Galeri galeri);
        void EditGaleri(Galeri galeri);
        void GaleriToggleStatus(int id);
    }
}

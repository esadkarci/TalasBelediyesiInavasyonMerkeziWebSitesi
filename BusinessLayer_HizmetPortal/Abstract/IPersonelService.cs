using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IPersonelService
    {
        void Add(Personel personel);
        void PersonelUpdate(Personel personel);
        Personel PersonelGetById(int id);
        List<Personel> GetAll();
        void PersonelDelete(Personel personel); 
    }
}

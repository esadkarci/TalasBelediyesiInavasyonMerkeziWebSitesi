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
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }

        public void Add(Personel personel)
        {
            _personelDal.Add(personel);
        }

        public List<Personel> GetAll()
        {
            return _personelDal.List();
        }

        public void PersonelDelete(Personel personel)
        {
            _personelDal.Delete(personel);
        }

        public Personel PersonelGetById(int id)
        {
            return _personelDal.Get(x => x.PersonelId == id);
        }

        public void PersonelUpdate(Personel personel)
        {
            _personelDal.Update(personel);
        }
    }
}

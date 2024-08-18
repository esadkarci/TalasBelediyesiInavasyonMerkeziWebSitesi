using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IDuyurularService
    {
        List<Duyurular> Getlist();
        void DuyurularAdd(Duyurular duyurular);
        Duyurular GetBuyID(int id);
        void DeleteDuyurular(Duyurular duyurular);
        void EditDuyurular(Duyurular duyurular);
        void DuyurularToggleStatus(int id);
    }
}

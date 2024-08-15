using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IEventSerrvice
    {
        void Add(Event events);
        void EventUpdate(Event events);
        Event EventGetById(int id);
        List<Event> GetAll();
        void ToggleStatus(int id);
    }
}

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
    public class EventMManager : IEventSerrvice
    {
        IEventDal _eventDal;

        public EventMManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public void Add(Event events)
        {
            _eventDal.Add(events);
        }

        public Event EventGetById(int id)
        {
            return _eventDal.Get(x => x.EventId == id);
        }

        public void EventUpdate(Event events)
        {
            _eventDal.Update(events);
        }

        public List<Event> GetAll()
        {
            return _eventDal.List();
        }

        public void ToggleStatus(int id)
        {
            var eventsss = _eventDal.GetById(id);
            if (eventsss != null)
            {
                eventsss.EventStatues = !eventsss.EventStatues;
                _eventDal.Update(eventsss);
            }
        }
    }
}

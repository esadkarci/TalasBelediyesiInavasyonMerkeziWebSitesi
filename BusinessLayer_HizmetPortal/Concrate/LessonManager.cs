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
    public class LessonManager:ILessonService
    {
        ILessonDal _lessondal;

        public LessonManager(ILessonDal lessondal)
        {
            _lessondal = lessondal;
        }

        public void LessonAdd(Lesson lesson)
        {
            _lessondal.Add(lesson);
        }

        public void LessonDelete(Lesson lesson)
        {
            _lessondal.Delete(lesson);
        }

        public List<Lesson> LessonGetAll()
        {
            return _lessondal.List();
        }

        public Lesson LessonGetById(int id)
        {
            return _lessondal.Get(x => x.LessonId == id);
        }

        public void LessonToggleStatus(int id)
        {
            var lesson = _lessondal.GetById(id);
            if (lesson != null)
            {
                lesson.LessonStatues = !lesson.LessonStatues;
                _lessondal.Update(lesson);
            }
        }

        public void LessonUpdate(Lesson lesson)
        {
            _lessondal.Update(lesson);
        }
    }
}

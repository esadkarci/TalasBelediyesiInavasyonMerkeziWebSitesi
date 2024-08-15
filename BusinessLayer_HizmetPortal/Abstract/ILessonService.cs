using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface ILessonService
    {
        void LessonAdd(Lesson lesson);
        void LessonUpdate(Lesson lesson);
        Lesson LessonGetById(int id);
        List<Lesson> LessonGetAll();
        void LessonToggleStatus(int id);
        void LessonDelete(Lesson lesson);
    }
}

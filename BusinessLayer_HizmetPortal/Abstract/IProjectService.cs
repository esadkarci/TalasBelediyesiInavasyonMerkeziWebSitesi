using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IProjectService
    {
        void ProjectAdd(Project project);
        void ProjectUpdate(Project project);
        Project ProjectGetById(int id);
        List<Project> ProjectGetAll();
        void ProjectToggleStatus(int id);
        void ProjectDelete(Project project);
    }
}

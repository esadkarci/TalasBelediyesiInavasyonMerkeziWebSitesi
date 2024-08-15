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
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectdal;

        public ProjectManager(IProjectDal projectdal)
        {
            _projectdal = projectdal;
        }

        public void ProjectAdd(Project project)
        {
            _projectdal.Add(project);
        }

        public void ProjectDelete(Project project)
        {
            _projectdal.Delete(project);
        }

        public List<Project> ProjectGetAll()
        {
            return _projectdal.List();
        }

        public Project ProjectGetById(int id)
        {
            return _projectdal.Get(x => x.ProjectId == id);
        }

        public void ProjectToggleStatus(int id)
        {
            var project = _projectdal.GetById(id);
            if (project != null)
            {
                project.ProjectStatues = !project.ProjectStatues;
                _projectdal.Update(project);
            }
        }

        public void ProjectUpdate(Project project)
        {
            _projectdal.Update(project);
        }
    }
}

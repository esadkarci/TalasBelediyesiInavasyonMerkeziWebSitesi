using EntityLayer_HizmetPortal.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer_HizmetPortal.Abstract
{
    public interface IStageService
    {
        void StageAdd(Stage stage);
        void StageUpdate(Stage stage);
        Stage StageGetById(int id);
        List<Stage> StageGetAll();
        void StageToggleStatus(int id);
    }
}

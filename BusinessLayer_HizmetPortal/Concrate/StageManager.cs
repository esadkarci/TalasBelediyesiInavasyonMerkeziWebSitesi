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
    public class StageManager:IStageService
    {
        IStageDal _stagedal;

        public StageManager(IStageDal stagedal)
        {
            _stagedal = stagedal;
        }

        public void StageAdd(Stage stage)
        {
            _stagedal.Add(stage);
        }

        public List<Stage> StageGetAll()
        {
           return _stagedal.List();
        }

        public Stage StageGetById(int id)
        {
            return _stagedal.Get(x => x.StageId == id);
        }

        public void StageToggleStatus(int id)
        {
            var stage = _stagedal.GetById(id);
            if (stage != null)
            {
                stage.StageStatues = !stage.StageStatues;
                _stagedal.Update(stage);
            }
        }

        public void StageUpdate(Stage stage)
        {
            _stagedal.Update(stage);
        }
    }
}

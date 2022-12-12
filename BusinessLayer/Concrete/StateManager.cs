using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StateManager : IStateService
    {
        IStateDal _villageDal;
        public StateManager(IStateDal villageDal)
        {
            _villageDal = villageDal;
        }

        public State GetById(int id)
        {
            return _villageDal.GetById(id);
        }

        public List<State> GetListAll()
        {
            return _villageDal.GetList();
        }
        /*public List<Village> GetVillageListWithCity()
        {
            return _villageDal.GetListWithCity();
        }*/
        public void TAdd(State t)
        {
            _villageDal.Insert(t);
        }

        public void TDelete(State t)
        {
            _villageDal.Delete(t);
        }

        public void TUpdate(State t)
        {
            _villageDal.Update(t);
        }
    }
}

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
    public class VillageManager : IVillageService
    {
        IVillageDal _villageDal;
        public VillageManager(IVillageDal villageDal)
        {
            _villageDal = villageDal;
        }

        public Village GetById(int id)
        {
            return _villageDal.GetById(id);
        }

        public List<Village> GetListAll()
        {
            return _villageDal.GetList();
        }

        public void TAdd(Village t)
        {
            _villageDal.Insert(t);
        }

        public void TDelete(Village t)
        {
            _villageDal.Delete(t);
        }

        public void TUpdate(Village t)
        {
            _villageDal.Update(t);
        }
    }
}

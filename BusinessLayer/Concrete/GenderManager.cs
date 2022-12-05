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
    public class GenderManager : IGenderService
    {
        IGenderDal _genderDal;
        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public Gender GetById(int id)
        {
            return _genderDal.GetById(id);
        }

        public List<Gender> GetListAll()
        {
            return _genderDal.GetList();
        }

        public void TAdd(Gender t)
        {
            _genderDal.Insert(t);
        }

        public void TDelete(Gender t)
        {
            _genderDal.Delete(t);
        }

        public void TUpdate(Gender t)
        {
            _genderDal.Update(t);
        }
    }
}

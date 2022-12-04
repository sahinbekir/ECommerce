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
    public class CityManager : ICityService
    {
        ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public City GetById(int id)
        {
            return _cityDal.GetById(id);
        }

        public List<City> GetListAll()
        {
            return _cityDal.GetList();
        }

        public void TAdd(City t)
        {
            _cityDal.Insert(t);
        }

        public void TDelete(City t)
        {
            _cityDal.Delete(t);
        }

        public void TUpdate(City t)
        {
            _cityDal.Update(t);
        }
    }
}

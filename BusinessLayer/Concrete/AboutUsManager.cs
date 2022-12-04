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
    public class AboutUsManager : IAboutUsService
    {
        IAboutUsDal _aboutUsDal;
        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }
        public AboutUs GetById(int id)
        {
            return _aboutUsDal.GetById(id);
        }

        public List<AboutUs> GetListAll()
        {
            return _aboutUsDal.GetList();
        }

        public void TAdd(AboutUs t)
        {
            _aboutUsDal.Insert(t);
        }

        public void TDelete(AboutUs t)
        {
            _aboutUsDal.Delete(t);
        }

        public void TUpdate(AboutUs t)
        {
            _aboutUsDal.Update(t);
        }
    }
}

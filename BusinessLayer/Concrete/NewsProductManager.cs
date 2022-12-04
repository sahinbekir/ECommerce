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
    public class NewsProductManager : INewsProductService
    {
        INewsProductDal _newsProductDal;
        public NewsProductManager(INewsProductDal newsProductDal)
        {
            _newsProductDal = newsProductDal;
        }

        public NewsProduct GetById(int id)
        {
            return _newsProductDal.GetById(id);
        }

        public List<NewsProduct> GetListAll()
        {
            return _newsProductDal.GetList();
        }

        public void TAdd(NewsProduct t)
        {
            _newsProductDal.Insert(t);
        }

        public void TDelete(NewsProduct t)
        {
            _newsProductDal.Delete(t);
        }

        public void TUpdate(NewsProduct t)
        {
            _newsProductDal.Update(t);
        }
    }
}

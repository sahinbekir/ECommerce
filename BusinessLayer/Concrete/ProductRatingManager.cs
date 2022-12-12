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
    public class ProductRatingManager : IProductRatingService
    {
        IProductRatingDal _productRatingDal;
        public ProductRatingManager(IProductRatingDal productRatingDal)
        {
            _productRatingDal = productRatingDal;
        }

        public ProductRating GetById(int id)
        {
            return _productRatingDal.GetById(id);
        }

        public List<ProductRating> GetListAll()
        {
            return _productRatingDal.GetList();
        }

        public void TAdd(ProductRating t)
        {
            _productRatingDal.Insert(t);
        }

        public void TDelete(ProductRating t)
        {
           _productRatingDal.Delete(t);
        }

        public void TUpdate(ProductRating t)
        {
            _productRatingDal.Update(t);
        }
    }
}

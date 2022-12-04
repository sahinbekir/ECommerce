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
    public class ProductCartManager : IProductCartService
    {
        IProductCartDal _productCartDal;
        public ProductCartManager(IProductCartDal productCartDal)
        {
            _productCartDal = productCartDal;
        }

        public ProductCart GetById(int id)
        {
            return _productCartDal.GetById(id);
        }

        public List<ProductCart> GetListAll()
        {
            return _productCartDal.GetList();
        }

        public void TAdd(ProductCart t)
        {
            _productCartDal.Insert(t);
        }

        public void TDelete(ProductCart t)
        {
            _productCartDal.Delete(t);
        }

        public void TUpdate(ProductCart t)
        {
            _productCartDal.Update(t);
        }
    }
}

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetProductById(int id)
        {
            return _productDal.GetListWithCBU().Where(a=>a.Id==id).ToList();
        }
        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetListAll()
        {
            return _productDal.GetList();
        }

        public void TAdd(Product t)
        {
            _productDal.Insert(t);
        }

        public void TDelete(Product t)
        {
            _productDal.Delete(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }

        public List<Product> GetProductListWithCBU()
        {
            return _productDal.GetListWithCBU();
        }

        public List<Product> GetBestSellerProductsList()
        {
            return _productDal.GetListWithCBU().Take(1).ToList();
        }

        public List<Product> GetLatestProductsList()
        {
            return _productDal.GetListWithCBU().OrderBy(x=>x.CreatedDate).Take(2).ToList();
        }

        public List<Product> GetHighestPerformingProductsList()
        {
            return _productDal.GetListWithCBU().Take(1).ToList();
        }
    }
}

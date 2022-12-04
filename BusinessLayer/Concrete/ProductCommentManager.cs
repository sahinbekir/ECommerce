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
    public class ProductCommentManager : IProductCommentService
    {
        IProductCommentDal _productCommentDal;
        public ProductCommentManager(IProductCommentDal productCommentDal)
        {
            _productCommentDal = productCommentDal;
        }

        public ProductComment GetById(int id)
        {
            return _productCommentDal.GetById(id);
        }

        public List<ProductComment> GetListAll()
        {
            return _productCommentDal.GetList();
        }

        public void TAdd(ProductComment t)
        {
            _productCommentDal.Insert(t);
        }

        public void TDelete(ProductComment t)
        {
            _productCommentDal.Delete(t);
        }

        public void TUpdate(ProductComment t)
        {
            _productCommentDal.Update(t);
        }
    }
}

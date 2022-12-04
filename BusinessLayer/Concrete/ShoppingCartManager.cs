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
    public class ShoppingCartManager : IShoppingCartService
    {
        IShoppingCartDal _shoppingCartDal;
        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }
        public ShoppingCart GetById(int id)
        {
            return _shoppingCartDal.GetById(id);
        }

        public List<ShoppingCart> GetListAll()
        {
            return _shoppingCartDal.GetList();
        }

        public void TAdd(ShoppingCart t)
        {
            _shoppingCartDal.Insert(t);
        }

        public void TDelete(ShoppingCart t)
        {
            _shoppingCartDal.Delete(t);
        }

        public void TUpdate(ShoppingCart t)
        {
            _shoppingCartDal.Update(t);
        }
    }
}

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
    public class StockAmountManager : IStockAmountService
    {
        IStockAmountDal _stockAmountDal;
        public StockAmountManager(IStockAmountDal stockAmountDal)
        {
            _stockAmountDal = stockAmountDal;
        }

        public StockAmount GetById(int id)
        {
            return _stockAmountDal.GetById(id);
        }

        public List<StockAmount> GetListAll()
        {
            return _stockAmountDal.GetList();
        }

        public void TAdd(StockAmount t)
        {
            _stockAmountDal.Insert(t);
        }

        public void TDelete(StockAmount t)
        {
            _stockAmountDal.Delete(t);
        }

        public void TUpdate(StockAmount t)
        {
            _stockAmountDal.Update(t);
        }
    }
}

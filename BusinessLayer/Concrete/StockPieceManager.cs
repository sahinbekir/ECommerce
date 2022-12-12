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
    public class StockPieceManager : IStockPieceService
    {
        IStockPieceDal _stockAmountDal;
        public StockPieceManager(IStockPieceDal stockAmountDal)
        {
            _stockAmountDal = stockAmountDal;
        }

        public StockPiece GetById(int id)
        {
            return _stockAmountDal.GetById(id);
        }

        public List<StockPiece> GetListAll()
        {
            return _stockAmountDal.GetList();
        }

        public void TAdd(StockPiece t)
        {
            _stockAmountDal.Insert(t);
        }

        public void TDelete(StockPiece t)
        {
            _stockAmountDal.Delete(t);
        }

        public void TUpdate(StockPiece t)
        {
            _stockAmountDal.Update(t);
        }
    }
}

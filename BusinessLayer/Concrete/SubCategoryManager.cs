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
    public class SubCategoryManager : ISubCategoryService
    {
        ISubCategoryDal _subCategoryDal;
        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }
        public SubCategory GetById(int id)
        {
            return _subCategoryDal.GetById(id);
        }

        public List<SubCategory> GetListAll()
        {
            return _subCategoryDal.GetList();
        }

        public void TAdd(SubCategory t)
        {
            _subCategoryDal.Insert(t);
        }

        public void TDelete(SubCategory t)
        {
            _subCategoryDal.Delete(t);
        }

        public void TUpdate(SubCategory t)
        {
            _subCategoryDal.Update(t);
        }
    }
}

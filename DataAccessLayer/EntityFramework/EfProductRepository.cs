using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductRepository : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetListWithCBU()
        {
            using (var c = new Context())
            {
                return c.Products?.Include(x=>x.Category)
                    .Include(x => x.SubCategory)
                    .Include(x => x.Brand)
                    .Include(x => x.User).ToList();
            }
        }
    }
}

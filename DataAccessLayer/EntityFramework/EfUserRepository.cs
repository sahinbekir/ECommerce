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
    public class EfUserRepository : GenericRepository<AppUser>, IUserDal
    {
        public List<AppUser> GetListWithCSG()
        {
            using (var c = new Context())
            {
                return c.Users?.Include(x => x.City)
                    .Include(x => x.State)
                    .Include(x => x.Gender).ToList();
            }
        }
    }
}

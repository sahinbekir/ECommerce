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
    public class EfStateRepository : GenericRepository<State>, IStateDal
    {
        /*
        public List<Village> GetListWithCity()
        {
            using (var c = new Context())
            {
                return c.Villages?.Include(x => x.City).ToList();
            }
        }*/
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductCommentService : IGenericService<ProductComment>
    {
        List<ProductComment> GetListByProduct(int id);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ShoppingCart
    {
        [Key]
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public int ShopCost { get; set; }
    }
}

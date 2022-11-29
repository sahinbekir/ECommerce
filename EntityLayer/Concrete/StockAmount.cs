using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class StockAmount
    {
        [Key]
        public int StockAmountId { get; set; }
        public int ProductId { get; set; }
        public int StockAmountScore { get; set; }
    }
}

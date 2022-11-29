using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string? ProductImage { get; set; }
        public string? ProductThumbnailImage { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductOwnerId { get; set; }
        public string? ProductVersion { get; set; }
        public int ProductCost { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public bool ProductStatus { get; set; }

    }

}

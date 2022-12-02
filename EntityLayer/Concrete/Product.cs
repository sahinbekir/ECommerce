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
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ThumbnailImgUrl { get; set; }
        public string? MovieUrl { get; set; }
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory? SubCategory { get; set; }
        public int UserId { get; set; }
        public AppUser? User { get; set; }
        public List<ProductComment>? ProductComments { get; set; }
        public string? Version { get; set; }
        public int Cost { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<StockAmount>? StockAmounts { get; set; }
        public List<ShoppingCart>? ShoppingCarts { get; set; }
        public List<ProductCart>? ProductCarts { get; set; }
    }
}
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
        public int SubCategoryId { get; set; }// public SubCategory? SubCategory { get; set; }
        public int UserId { get; set; }// public AppUser? User { get; set; }
        public string? Version { get; set; }
        public int Cost { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

    }

}

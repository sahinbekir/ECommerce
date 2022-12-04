using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.User.Models
{
    public class AddProductViewModel
    {
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please valid Name")]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "Please valid Description")]
        public string Description { get; set; }

        [Display(Name = "Product ImageUrl")]
        [Required(ErrorMessage = "Please valid ImageUrl")]
        public IFormFile ImageUrl { get; set; }

        [Display(Name = "Product ThumbnailImgUrl")]
        [Required(ErrorMessage = "Please valid ThumbnailImgUrl")]
        public IFormFile ThumbnailImgUrl { get; set; }

        [Display(Name = "Product MovieUrl")]
        [Required(ErrorMessage = "Please valid MovieUrl")]
        public IFormFile MovieUrl { get; set; }

        [Display(Name = "Product Brand")]
        [Required(ErrorMessage = "Please valid Brand")]
        public int BrandId { get; set; }

        [Display(Name = "Product SubCategory")]
        [Required(ErrorMessage = "Please valid SubCategory")]
        public int SubCategoryId { get; set; }

        [Display(Name = "Product Version")]
        [Required(ErrorMessage = "Please valid Version")]
        public string Version { get; set; }

        [Display(Name = "Product Cost")]
        [Required(ErrorMessage = "Please valid Cost")]
        public int Cost { get; set; }
    }
}

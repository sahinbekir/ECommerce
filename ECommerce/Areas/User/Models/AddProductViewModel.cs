using EntityLayer.Concrete;

namespace ECommerce.Areas.User.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public IFormFile? ThumbnailImgUrl { get; set; }
        public IFormFile? MovieUrl { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public string Version { get; set; }
        public int Cost { get; set; }
    }
}

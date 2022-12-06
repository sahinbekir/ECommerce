using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.User.Models
{
    public class ProfilePhotoViewModel
    {
        public IFormFile? ProfilePhoto { get; set; }
        public string Address { get; set; }
    }
}

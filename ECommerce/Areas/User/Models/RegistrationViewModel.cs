using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.User.Models
{
    public class RegistrationViewModel
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Address { get; set; }
        public int GenderId { get; set; }
    }
}

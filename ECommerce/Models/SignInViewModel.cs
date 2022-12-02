using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Username write please")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password write please")]
        public string Password { get; set; }
    }
}

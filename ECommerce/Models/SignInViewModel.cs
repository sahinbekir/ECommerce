using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Username write")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password write")]
        public string Password { get; set; }
    }
}

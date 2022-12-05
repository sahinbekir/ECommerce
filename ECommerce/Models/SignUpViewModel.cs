using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class SignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Please valid Name and Surname")]
        public string FullName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please valid Password")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "Not Same Password")]
        public string ConfirmedPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please valid Mail")]
        public string Email { get; set; }

        [Display(Name = "ConfirmedEmail")]
        [Compare("Email", ErrorMessage = "Not Same Email")]
        public string ConfirmedEmail { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please valid Username")]
        public string UserName { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please valid PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "BornDate")]
        [Required(ErrorMessage = "Please valid Born Date")]
        public DateTime BornDate { get; set; }
    }
}

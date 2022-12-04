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
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Please valid Mail")]
        public string Email { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please valid Username")]
        public string UserName { get; set; }

        [Display(Name = "ImgUrl")]
        [Required(ErrorMessage = "Please valid ImgUrl")]
        public IFormFile ImageUrl { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Please valid PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please valid City")]
        public int CityId { get; set; }

        [Display(Name = "Village")]
        [Required(ErrorMessage = "Please valid Village")]
        public string Village { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please valid Address")]
        public string Address { get; set; }

        [Display(Name = "BornDate")]
        [Required(ErrorMessage = "Please valid BornDate")]
        public DateTime BornDate { get; set; }
    }
}

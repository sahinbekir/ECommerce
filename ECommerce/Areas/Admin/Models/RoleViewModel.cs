using System.ComponentModel.DataAnnotations;

namespace ECommerce.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Please Write to a Role Name")]
        public string name { get; set; }
    }
}

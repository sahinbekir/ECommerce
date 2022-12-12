using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public string? Name { get; set; }
        public List<AppUser>? Users { get; set; }
    }
}

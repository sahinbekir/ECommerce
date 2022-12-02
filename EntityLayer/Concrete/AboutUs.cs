using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }
        public string? DetailsV1 { get; set; }
        public string? DetailsV2 { get; set; }
        public string? ImageV1 { get; set; }
        public string? ImageV2 { get; set; }
        public string? MovieV1 { get; set; }
        public string? MapLocationV1 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

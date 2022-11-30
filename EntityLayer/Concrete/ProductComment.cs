using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductComment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }// public AppUser? User { get; set; }
        public int ProductId { get; set; }// public Product? Product { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public int Score { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
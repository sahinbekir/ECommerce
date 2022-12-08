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
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserImage { get; set; }
        public string? UserFullName { get; set; }
        public string? UserName { get; set; }
        public string? CommentTitle { get; set; }
        public string? CommentContent { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
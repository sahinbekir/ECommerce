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
        public int ProductCommentId { get; set; }
        public int CommenterId { get; set; }
        public int ProductId { get; set; }
        public string? ProductCommentTitle { get; set; }
        public string? ProductCommentContent { get; set; }
        public int ProductScore { get; set; }
        public DateTime ProductCommentCreateDate { get; set; }
        public bool ProductCommentStatus { get; set; }
    }
}
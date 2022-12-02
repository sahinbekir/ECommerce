using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int MessageSender { get; set; }
        public int MessageReceiver { get; set; }
        public string? Subject { get; set; }
        public string? Context { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public AppUser? SenderUser { get; set; }
        public AppUser? ReceiverUser { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
        public string? ImageUrl { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public int VillageId { get; set; }
        public Village? Village { get; set; }
        public string? Address { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }
        public DateTime BornDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ProfileUpdatedDate { get; set; }
        public DateTime? BlockStartDate { get; set; }
        public DateTime? BlockEndDate { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product>? Products { get; set; }
        public List<NewsProduct>? NewsProducts { get; set; }
        public virtual ICollection<Message>? UserSender { get; set; }
        public virtual ICollection<Message>? UserReceiver { get; set; }
    }
}
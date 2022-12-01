using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SAHINBEKIR\\SQLEXPRESS01;database=EcommerceDb; integrated security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.UserSender)
                .HasForeignKey(z => z.MessageSender)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.UserReceiver)
                .HasForeignKey(z => z.MessageReceiver)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<StockAmount>? StockAmounts { get; set; }
        public DbSet<ProductComment>? ProductComments { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<SubCategory>? SubCategories { get; set; }
        public DbSet<ProductRating>? ProductRatings { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<Notification>? Notifications { get; set; }
        public DbSet<NewsProduct>? NewsProducts { get; set; }
        public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
        public DbSet<ProductCart>? ProductCarts { get; set; }
        public DbSet<Brand>? Brands { get; set; }
    }
}
// Migration Commands *Packet Manager*
/*
->add-migration migname
->remove-migration for Re-Do
->update-database
*/

// Database ProductRating Triggers SQL Command
/*
Create Trigger AddProductInRaitingTable
On Products
After Insert
As
Declare @ID int
Select @ID=Id from inserted
Insert Into ProductRatings (ProductId,TotalScore,RatingCount)
Values (@ID,0,0)
*/

/*
Create Trigger AddScoreInProductComment
On ProductComments
After Insert
As
Declare @ID int
Declare @Score int
Declare @RaitingCount int
Select @ID=Id, @Score=ProductScore from inserted
Update ProductRatings Set TotalScore=TotalScore+@Score, RatingCount+=1
Where ProductId=@ID
*/
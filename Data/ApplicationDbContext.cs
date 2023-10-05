using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static WeConnectBackend.Models.PortfolioModel.Projects;
using static WeConnectBackend.Models.RoleModels.UserRoles;
using static WeConnectBackend.Models.ServiceCategory;
using static WeConnectBackend.Models.ServiceMessages;
using static WeConnectBackend.Models.ServiceModel;
using static WeConnectBackend.Models.ServiceOrders;
using static WeConnectBackend.Models.ServiceReview;
using static WeConnectBackend.Models.UserModels.AppUsers;
using static WeConnectBackend.Models.UserModels.Education;
using static WeConnectBackend.Models.UserModels.Profiles;

namespace WeConnectBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProfile>()
                .HasOne(u => u.User)
                .WithOne()
                .HasForeignKey<UserProfile>(u => u.UserId);
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.Roles);
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.Service);
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.Reviews);
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.UserEducation);

            modelBuilder.Entity<Service>()
                .HasMany(u => u.Category);
            modelBuilder.Entity<Service>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.Service);
            
            modelBuilder.Entity<DirectMessage>()
                .HasOne(d => d.Sender)
                .WithMany()  // Specify the navigation property for the inverse relationship, if needed
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Specify the desired behavior

            modelBuilder.Entity<DirectMessage>()
                .HasOne(d => d.Receiver)
                .WithMany()
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DirectMessage>()
                .HasOne(d => d.Service)
                .WithMany()
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Order>()
                .HasOne(o => o.Seller)
                .WithMany()
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.Restrict);
                //.OnUpdate(UpdateBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany()
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);
                //.OnUpdate(UpdateBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Service)
                .WithMany()
                .HasForeignKey(o => o.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
                //.OnUpdate(UpdateBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Service)
                .WithMany()
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

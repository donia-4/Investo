using Investo.Models;
using Microsoft.EntityFrameworkCore;

namespace Investo.Data
{
    public class CoreEntitiesDbContext : DbContext
    {
        public CoreEntitiesDbContext(DbContextOptions<CoreEntitiesDbContext> options)
             : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CoreEntities"); 
            base.OnModelCreating(modelBuilder);
        }
        // Main Entities
        public DbSet<Project> Projects { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Category> Categories { get; set; }

        // User Types
        public DbSet<User> Users { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<BusinessOwner> BusinessOwners { get; set; }

    }
}

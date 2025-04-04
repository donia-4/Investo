using Investo.Models;
using Microsoft.EntityFrameworkCore;

namespace Investo.Data
{
    public class RealTimeDbContext : DbContext  
    {
        public RealTimeDbContext(DbContextOptions<RealTimeDbContext> options)
             : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RealTime"); 
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<OpenChatRequest> OpenChatRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

    }
}

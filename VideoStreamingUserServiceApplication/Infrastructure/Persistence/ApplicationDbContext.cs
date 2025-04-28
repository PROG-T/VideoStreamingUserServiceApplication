using Microsoft.EntityFrameworkCore;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.Entities;
using VideoStreamingUserServiceApplication.Infrastructure.FluentConfig;

namespace VideoStreamingUserServiceApplication.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options) 
        {
            
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }

        
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserProfileConfig());
        }
        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        //
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

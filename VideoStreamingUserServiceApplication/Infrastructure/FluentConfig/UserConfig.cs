using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoStreamingUserServiceApplication.Domain.Entities;
using VideoStreamingUserServiceApplication.Domain.Enums;

namespace VideoStreamingUserServiceApplication.Infrastructure.FluentConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(p => p.UserProfile).WithOne( x=> x.User).HasForeignKey<UserProfile>(p => p.Id);
            builder.Property(p=> p.Subscription).HasConversion(p=> p.ToString(), p => (Subscription)Enum.Parse(typeof(Subscription),p));
            builder.Property(p=> p.Role).HasConversion(p=> p.ToString(), p => (UserRole)Enum.Parse(typeof(UserRole),p));
        }
    }
}

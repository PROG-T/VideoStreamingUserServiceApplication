using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoStreamingUserServiceApplication.Domain.Entities;

namespace VideoStreamingUserServiceApplication.Infrastructure.FluentConfig
{
    public class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasOne(x => x.User).WithOne(x => x.UserProfile).HasForeignKey<UserProfile>(x=> x.UserId);
            builder.HasIndex(x => x.DisplayName).IsUnique();
        }
    }
}

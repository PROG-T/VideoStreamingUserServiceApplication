using VideoStreamingUserServiceApplication.Domain.Entities;

namespace VideoStreamingUserServiceApplication.Applications.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

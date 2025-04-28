using VideoStreamingUserServiceApplication.Domain.Entities;

namespace VideoStreamingUserServiceApplication.Applications.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
       Task<User> GetUserByEmail(string email);
    }
}

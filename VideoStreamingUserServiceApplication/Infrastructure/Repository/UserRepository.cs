using Microsoft.EntityFrameworkCore;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Domain.Entities;
using VideoStreamingUserServiceApplication.Infrastructure.Persistence;

namespace VideoStreamingUserServiceApplication.Infrastructure.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await applicationDbContext.User.AddAsync(user);
            await applicationDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await applicationDbContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
              applicationDbContext.User.Update(user);  
            await applicationDbContext.SaveChangesAsync();
            return user;
        }
    }
}

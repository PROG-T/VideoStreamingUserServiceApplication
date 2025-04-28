using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Infrastructure.Persistence;

namespace VideoStreamingUserServiceApplication.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UnitOfWorkRepository(ApplicationDbContext context)
        {
            applicationDbContext = context;
        }

        private IUserRepository userRepository;
        public IUserRepository UserRepository => userRepository ??= new UserRepository(applicationDbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
